using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coderush.Controllers
{
    [Authorize(Roles = Pages.MainMenu.PartType.RoleName)]
    public class PartTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}