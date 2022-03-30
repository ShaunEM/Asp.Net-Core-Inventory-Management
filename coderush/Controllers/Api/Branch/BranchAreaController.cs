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
    [Route("api/BranchArea")]
    public class BranchAreaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BranchAreaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BranchArea
        [HttpGet]
        public async Task<IActionResult> GetBranchArea()
        {
            List<BranchArea> Items = await _context.BranchArea.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }




        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetAreasByBranchId(int id)
        {
            List<BranchArea> Items = await _context.BranchArea.Where(x => x.BranchId.Equals(id)).ToListAsync();
            return Ok(Items);
        }




        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<BranchArea> payload)
        {
            BranchArea m = payload.value;
            _context.BranchArea.Add(m);
            _context.SaveChanges();
            return Ok(m);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<BranchArea> payload)
        {
            BranchArea m = payload.value;
            _context.BranchArea.Update(m);
            _context.SaveChanges();
            return Ok(m);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<BranchArea> payload)
        {
            BranchArea m = _context.BranchArea
                .Where(x => x.BranchAreaId == (int)payload.key)
                .FirstOrDefault();
            _context.BranchArea.Remove(m);
            _context.SaveChanges();
            return Ok(m);

        }
    }
}