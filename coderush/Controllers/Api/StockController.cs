using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coderush.Data;
using coderush.Models;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Stock")]
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Stock> Items = await _context.Stock.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertAsync([FromBody] CrudViewModel<Stock> payload)
        {
            Stock stock = payload.value;

            List<StockBilOfMaterial> stockBilOfMaterials = await _context.StockBilOfMaterial.Where(x => x.StockId == stock.StockId).ToListAsync();
            foreach(StockBilOfMaterial stockBilOfMaterial in stockBilOfMaterials)
            {
                //_context.Inventory.Where(x=>x.BranchStoreId == stock.)
                //_context.Inventory.Add(new Inventory() {
                //    BranchStoreId
                //    StockId
                //    DateTime
                //    InventoryTypeId
                //    QTYChange
                //    QTY
                //});
            }

        _context.Stock.Add(stock);
            _context.SaveChanges();
            return Ok(stock);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Stock> payload)
        {
            Stock stock = payload.value;
            _context.Stock.Update(stock);
            _context.SaveChanges();
            return Ok(stock);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Stock> payload)
        {
            Stock stock = _context.Stock
                .Where(x => x.StockId == Convert.ToInt32(payload.key))
                .FirstOrDefault();
            _context.Stock.Remove(stock);
            _context.SaveChanges();
            return Ok(stock);
        }






        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByStockId([FromRoute] int id)
        {
            Stock stock  = await _context.Stock.SingleOrDefaultAsync(x => x.StockId.Equals(id));
            return Ok(stock);
        }


    }
}