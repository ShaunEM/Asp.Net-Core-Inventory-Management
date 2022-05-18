using coderush.Data;
using coderush.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace coderush.Controllers
{
    public class StockController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StockType()
        {
            return View();
        }

        public IActionResult StockBilOfMaterial(int id)
        {
            Stock item = _context.Stock.SingleOrDefault(x => x.StockId.Equals(id));
            return View(item);
        }
    }
}