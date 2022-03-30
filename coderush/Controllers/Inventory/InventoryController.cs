using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coderush.Data;
using coderush.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coderush.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ByBranchArea(int id)
        {
            // Show branch areas inventory (parts and product?)

            // TODO
            // create a view (include PART, and PRODUCT)
            // Create PART VIEW model (Name, internal part number, QTY.. value?)
            // Create PRODUCT VIEW model (Name, internal part number, QTY.. value?)
            // create the view, display parts and products in separate tables.

          
            



            Product item = _context.Product.SingleOrDefault(x => x.ProductId.Equals(id));
            if (item == null)
            {
                return NotFound();
            }
            return View();
        }
    }
}