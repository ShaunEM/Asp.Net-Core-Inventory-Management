using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coderush.Controllers
{
    [Authorize(Roles = Pages.MainMenu.SalesOrder.RoleName)]
    public class SalesOrderDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}