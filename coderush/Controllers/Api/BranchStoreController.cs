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
    [Route("api/BranchStore")]
    public class BranchStoreController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BranchStoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BranchArea
        [HttpGet]
        public async Task<IActionResult> GetBranchStore()
        {
            List<BranchStore> Items = await _context.BranchStore.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }



        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBranchStoresByBranchId(int id)
        {
            List<BranchStore> Items = await _context.BranchStore.Where(x => x.BranchId.Equals(id)).ToListAsync();
            return Ok(Items);
        }




        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<BranchStore> payload)
        {
            BranchStore m = payload.value;
            _context.BranchStore.Add(m);
            _context.SaveChanges();
            return Ok(m);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<BranchStore> payload)
        {
            BranchStore m = payload.value;
            _context.BranchStore.Update(m);
            _context.SaveChanges();
            return Ok(m);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<BranchStore> payload)
        {
            BranchStore m = _context.BranchStore
                .Where(x => x.BranchStoreId == (int)payload.key)
                .FirstOrDefault();
            _context.BranchStore.Remove(m);
            _context.SaveChanges();
            return Ok(m);

        }
    }
}