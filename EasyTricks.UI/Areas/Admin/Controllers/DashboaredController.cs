using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyTricks.UI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Super Admin")]
    public class DashboaredController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
