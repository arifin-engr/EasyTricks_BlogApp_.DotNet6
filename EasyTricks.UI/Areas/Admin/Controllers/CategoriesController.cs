using EasyTricks.DAL.Repositories.IRepositories;
using EasyTricks.Models.AppEntity;
using EasyTricks.Models.AppVM;
using Microsoft.AspNetCore.Mvc;

namespace EasyTricks.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
       
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Upsert(int?id)
        {
            CategoryVM categoryVM=new CategoryVM();
            if (id==0)
            {
                return View();
            }
            else
            {
                categoryVM.Category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
                return View(categoryVM);
            }
           

        }
        [HttpPost]
        
        public IActionResult Upsert(CategoryVM categoryVM)
        {

            if (!ModelState.IsValid)
            {
                var model = new Category();
                model=categoryVM.Category;
                if (model.Id==0)
                {
                    model.CreatedDate = DateTime.Now;
                    _unitOfWork.Category.Add(model);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    model.ModifiedDate = DateTime.Now;
                    _unitOfWork.Category.Update(model);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(categoryVM);

        }

        #region API Call

        public IActionResult GetAll()
        {
            var categoryList=_unitOfWork.Category.GetAll();

            return Json(new {data= categoryList });
        }
        #endregion
    }
}
