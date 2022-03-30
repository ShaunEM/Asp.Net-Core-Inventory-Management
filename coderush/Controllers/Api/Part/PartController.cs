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
    [Route("api/Part")]
    public class PartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Part
        [HttpGet]
        public async Task<IActionResult> GetPart()
        {
            List<Part> Items = await _context.Part.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }
        

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByPartTypeId(int id)
        {
            List<Part> Items = await _context.Part.Where(x => x.PartTypeId.Equals(id)).ToListAsync();
            //return Ok(new { Items, Items.Count });
            return Ok(Items);
        }


        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Part> payload)
        {
            Part part = payload.value;
            _context.Part.Add(part);
            _context.SaveChanges();
            return Ok(part);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Part> payload)
        {
            Part part = payload.value;
            _context.Part.Update(part);
            _context.SaveChanges();
            return Ok(part);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Part> payload)
        {
            Part part = _context.Part
                .Where(x => x.PartId == Convert.ToInt32(payload.key))
                .FirstOrDefault();
            _context.Part.Remove(part);
            _context.SaveChanges();
            return Ok(part);

        }
    }
}