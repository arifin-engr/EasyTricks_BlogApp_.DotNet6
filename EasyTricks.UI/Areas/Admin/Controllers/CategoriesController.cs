using EasyTricks.DAL.Repositories.IRepositories;
using EasyTricks.Models.AppEntity;
using EasyTricks.Models.AppVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EasyTricks.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Super Admin")]
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
            CategoryVM categoryVM = new()
            {
                Category = new Category()
            };
           
            if (id==0 || id==null)
            {
                return View(categoryVM);
            }
            else
            {
                categoryVM.Category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
                return View(categoryVM);
            }
           

        }
        [HttpPost]
     
        
        public IActionResult Upsert(CategoryVM obj)
        {
           
            if (ModelState.IsValid)
            {
                var model = new Category();
                model= obj.Category;
                if (model.Id==0)
                {
                    model.CreatedDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    _unitOfWork.Category.Add(model);
                    _unitOfWork.Save();
                    TempData["success"] = "Successfully Created";
                    return RedirectToAction("Index");
                }
                else
                {
                    model.ModifiedDate = DateTime.Now;
                    _unitOfWork.Category.Update(model);
                    _unitOfWork.Save();
                    TempData["success"] = "Successfully Updated";
                    return RedirectToAction("Index");
                }
            }
            
            return View(obj);

        }

        #region API Call

        [HttpGet]

        public IActionResult GetAll()
        {
            var categoryList=_unitOfWork.Category.GetAll();

            return Json(new {data= categoryList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj=_unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (obj==null)
            {
                return Json(new {success=false,message="Error while Deleting"});
            }
            else
            {
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Deleted Successfully" });
            }
        }
        #endregion
    }
}
