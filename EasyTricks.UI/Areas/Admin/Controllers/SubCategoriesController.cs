using EasyTricks.DAL.Repositories.IRepositories;
using EasyTricks.Models.AppEntity;
using EasyTricks.Models.AppVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyTricks.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Super Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubCategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Upsert(int?id)
        {
            List<Category> categoryList = new List<Category>();
            categoryList = _unitOfWork.Category.GetAll().ToList();
            SubCategoryVM subCategoryVM = new()
            {
                SubCategory = new SubCategory(),
                CategoryList = categoryList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };


            if (id==0||id==null)
            {
                return View(subCategoryVM);
            }

            else
            {
                subCategoryVM.SubCategory = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
                if (subCategoryVM.SubCategory==null)
                {
                    return NotFound();
                }
                return View (subCategoryVM);
                
            }
           
        }

        [HttpPost]
        public IActionResult Upsert(SubCategoryVM obj)
        {
            if (ModelState.IsValid)
            {
                var model = new SubCategory();
                model=obj.SubCategory;
                if (model.Id==0)
                {
                    model.CreatedDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    _unitOfWork.SubCategory.Add(model);
                    _unitOfWork.Save();
                    TempData["Success"] = "Successfully Created";
                    return RedirectToAction("Index");
                }
                else
                {
                   
                    model.ModifiedDate = DateTime.Now;
                    _unitOfWork.SubCategory.Update(model);
                    _unitOfWork.Save();
                    TempData["Success"] = "Successfully Update";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
           

        }

        #region API Call

        [HttpGet]
        public IActionResult GetAll()
        {
            var subCategoryList= _unitOfWork.SubCategory.GetAll(includeProperties:"Category");
            return Json(new {data= subCategoryList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.SubCategory.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            else
            {
                _unitOfWork.SubCategory.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Deleted Successfully" });
            }
        }

       
        #endregion
    }
}
