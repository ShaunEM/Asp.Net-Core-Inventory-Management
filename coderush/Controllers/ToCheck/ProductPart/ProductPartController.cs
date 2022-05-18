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
    [Authorize(Roles = Pages.MainMenu.Product.RoleName)]
    public class ProductPartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductPartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            Product item = _context.Product.SingleOrDefault(x => x.ProductId.Equals(id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
    }
}