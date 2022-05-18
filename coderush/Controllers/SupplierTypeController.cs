using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coderush.Controllers
{
    [Authorize(Roles = Pages.MainMenu.SupplierType.RoleName)]
    public class SupplierTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}