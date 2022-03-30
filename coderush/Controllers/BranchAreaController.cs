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
    [Authorize(Roles = Pages.MainMenu.BranchArea.RoleName)]
    public class BranchAreaController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BranchAreaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inventory(int id)
        {
            BranchArea item = _context.BranchArea.SingleOrDefault(x => x.BranchAreaId.Equals(id));
            return View(item);
        }
        
    }
}