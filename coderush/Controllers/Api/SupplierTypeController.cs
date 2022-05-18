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
    [Route("api/SupplierType")]
    public class SupplierTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupplierTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SupplierType
        [HttpGet]
        public async Task<IActionResult> GetSupplierType()
        {
            List<SupplierType> Items = await _context.SupplierType.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody]CrudViewModel<SupplierType> payload)
        {
            SupplierType supplierType = payload.value;
            _context.SupplierType.Add(supplierType);
            _context.SaveChanges();
            return Ok(supplierType);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody]CrudViewModel<SupplierType> payload)
        {
            SupplierType supplierType = payload.value;
            _context.SupplierType.Update(supplierType);
            _context.SaveChanges();
            return Ok(supplierType);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody]CrudViewModel<SupplierType> payload)
        {
            SupplierType supplierType = _context.SupplierType
                .Where(x => x.SupplierTypeId == (int)payload.key)
                .FirstOrDefault();
            _context.SupplierType.Remove(supplierType);
            _context.SaveChanges();
            return Ok(supplierType);

        }
    }
}