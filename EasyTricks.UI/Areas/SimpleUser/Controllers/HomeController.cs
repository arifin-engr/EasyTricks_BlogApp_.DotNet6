using EasyTricks.DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace EasyTricks.UI.Areas.SimpleUser.Controllers
{
    [Area("SimpleUser")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {


            return View(unitOfWork.Article.GetAll().ToList());
        }
    }
}
