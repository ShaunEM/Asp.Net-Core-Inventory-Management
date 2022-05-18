using System.Linq;
using Microsoft.AspNetCore.Mvc;
using coderush.Data;
using coderush.Models;
using coderush.Models.SyncfusionViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace coderush.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/StockType")]
    public class StockTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StockTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<StockType> payload)
        {
            StockType item = payload.value;
            _context.StockType.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<StockType> payload)
        {
            StockType item = payload.value;
            _context.StockType.Update(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<StockType> payload)
        {
            StockType item = _context.StockType
                .Where(x => x.StockTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.StockType.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }







        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<StockType> Items = await _context.StockType.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }


    }
}