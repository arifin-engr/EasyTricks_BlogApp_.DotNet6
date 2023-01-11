using Microsoft.AspNetCore.Mvc;

namespace EasyTricks.UI.Areas.SimpleUser.Controllers
{
    [Area("SimpleUser")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
