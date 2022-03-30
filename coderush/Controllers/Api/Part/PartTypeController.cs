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
    [Route("api/PartType")]
    public class PartTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SupplierType
        [HttpGet]
        public async Task<IActionResult> GetPartType()
        {
            List<PartType> Items = await _context.PartType.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<PartType> payload)
        {
            PartType item = payload.value;
            _context.PartType.Add(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<PartType> payload)
        {
            PartType item = payload.value;
            _context.PartType.Update(item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<PartType> payload)
        {
            PartType item = _context.PartType
                .Where(x => x.PartTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.PartType.Remove(item);
            _context.SaveChanges();
            return Ok(item);

        }
    }
}