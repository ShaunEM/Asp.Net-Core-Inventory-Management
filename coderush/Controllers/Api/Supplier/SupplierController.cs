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
    [Route("api/Supplier")]
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Supplier
        [HttpGet]
        public async Task<IActionResult> GetSupplier()
        {
            List<Supplier> Items = await _context.Supplier.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<Supplier> payload)
        {
            Supplier supplier = payload.value;
            _context.Supplier.Add(supplier);
            _context.SaveChanges();
            return Ok(supplier);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<Supplier> payload)
        {
            Supplier supplier = payload.value;
            _context.Supplier.Update(supplier);
            _context.SaveChanges();
            return Ok(supplier);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<Supplier> payload)
        {
            Supplier supplier = _context.Supplier
                .Where(x => x.SupplierId == Convert.ToInt32(payload.key))
                .FirstOrDefault();
            _context.Supplier.Remove(supplier);
            _context.SaveChanges();
            return Ok(supplier);

        }
    }
}