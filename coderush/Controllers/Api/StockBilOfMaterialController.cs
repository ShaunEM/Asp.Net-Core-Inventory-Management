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
    [Route("api/StockBilOfMaterial")]
    public class StockBilOfMaterialController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StockBilOfMaterialController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet("[action]/{id}")]
        public IActionResult GetBilOfMaterial([FromRoute] int id)
        {
            var Items = (from bom in _context.StockBilOfMaterial
                         join s in _context.Stock on bom.Child_StockId equals s.StockId
                             select new
                             {
                                 StockBilOfMaterialId = bom.StockBilOfMaterialId,
                                 StockId = bom.StockId,
                                 Child_StockId = s.StockId,
                                 s.StockName,
                                 s.InternalPartNumber,
                                 bom.QTY
                             }
                         )
                         .Where(bom => bom.StockId == id);

            int Count = Items.Count();
            return Ok(new { Items, Count });
        }




        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<StockBilOfMaterial> payload)
        {
            StockBilOfMaterial stockBilOfMaterial = payload.value;
            _context.StockBilOfMaterial.Add(stockBilOfMaterial);
            _context.SaveChanges();
            return Ok(stockBilOfMaterial);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<StockBilOfMaterial> payload)
        {
            StockBilOfMaterial stockBilOfMaterial = payload.value;
            _context.StockBilOfMaterial.Update(stockBilOfMaterial);
            _context.SaveChanges();
            return Ok(stockBilOfMaterial);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<StockBilOfMaterial> payload)
        {
            StockBilOfMaterial stockBilOfMaterial = _context.StockBilOfMaterial
                .Where(x => x.StockBilOfMaterialId == Convert.ToInt32(payload.key))
                .FirstOrDefault();
            _context.StockBilOfMaterial.Remove(stockBilOfMaterial);
            _context.SaveChanges();
            return Ok(stockBilOfMaterial);
        }



        //[HttpGet("[action]/{id}")]
        //public async Task<IActionResult> GetByPartTypeId(int id)
        //{
        //    throw new NotImplementedException();
        //    //List<Stock> Items = await _context.Part.Where(x => x.PartTypeId.Equals(id)).ToListAsync();
        //    ////return Ok(new { Items, Items.Count });
        //    //return Ok(Items);
        //}



    }
}