using EasyTricks.DAL.Repositories.IRepositories;
using EasyTricks.Models.AppVM;
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
        public IActionResult Details(int ?id)
        {
            var article = new ArticleVM();
             article.Article = unitOfWork.Article.GetFirstOrDefault(x => x.Id == id);

            return View(article);
        }
    }
}
