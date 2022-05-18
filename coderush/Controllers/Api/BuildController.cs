using coderush.Data;
using coderush.Models;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Build")]
    public class BuildController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BuildController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Build> Items = await _context.Build.ToListAsync();
            return Ok(new {
                Items,
                Items.Count }
            );
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertAsync([FromBody] CrudViewModel<Build> payload)
        {
            Build build = payload.value;

            List<StockBilOfMaterial> stockBilOfMaterials = await _context.StockBilOfMaterial.Where(x => x.StockId == build.StockId).ToListAsync();
            foreach (StockBilOfMaterial stockBilOfMaterial in stockBilOfMaterials)
            {
                Inventory childInventory = _context.Inventory.Where(x => x.BranchStoreId == build.BranchStoreId && x.StockId == stockBilOfMaterial.Child_StockId)?.OrderByDescending(x => x.InventoryId)?.FirstOrDefault();

                int qty = (stockBilOfMaterial.QTY * build.QTY) * -1;
                _context.Inventory.Add(new Inventory() {
                    BranchStoreId = build.BranchStoreId,
                    StockId = stockBilOfMaterial.Child_StockId,
                    DateTime = DateTime.Now,
                    //InventoryTypeId = 2,
                    QTYChange = qty,
                    QTY = (childInventory?.QTY ?? 0) + qty
                });
            }

            Inventory inventory = (Inventory)_context.Inventory.Where(x => x.BranchStoreId == build.BranchStoreId && x.StockId == build.StockId)?.OrderByDescending(x => x.InventoryId)?.FirstOrDefault();
            _context.Inventory.Add(new Inventory()
            {
                BranchStoreId = build.BranchStoreId,
                StockId = build.StockId,
                DateTime = DateTime.Now,
                //InventoryTypeId = 2,
                QTYChange = build.QTY,
                QTY = (inventory?.QTY ?? 0) + build.QTY
            });

            _context.Build.Add(build);
            _context.SaveChanges();
            return Ok(inventory);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Build> payload)
        {
            Build m = payload.value;
            _context.Build.Update(m);
            _context.SaveChanges();
            return Ok(m);
        }

    }
}
