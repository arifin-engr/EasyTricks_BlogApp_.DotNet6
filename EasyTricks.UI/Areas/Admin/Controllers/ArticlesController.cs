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
    public class ArticlesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHost;
        public ArticlesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHost)
        {
            _unitOfWork = unitOfWork;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Upsert(int?id)
        {
            List<Category>categoryList= new List<Category>();
            List<SubCategory>subCategoryList= new List<SubCategory>();
            categoryList = _unitOfWork.Category.GetAll().ToList();
            subCategoryList = _unitOfWork.SubCategory.GetAll().ToList();
            ArticleVM articleVM = new()
            {
                Article = new Article(),

                CategoryList = categoryList.Select(i=>new SelectListItem
                {
                    Text=i.Name,
                    Value=i.Id.ToString()
                }),
                SubCategoryList = subCategoryList.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })

            };
            if (id==null|| id==0)
            {
                return View(articleVM);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Upsert(ArticleVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                var model = new Article();
                model=obj.Article;
                string mRoot = _webHost.WebRootPath;
                if (file!=null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string filePath=Path.Combine(mRoot,@"images\ContentImages");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileExtention = file.FileName;
                    if (model.ImagePath != null)
                    {
                        string oldPath = Path.Combine(mRoot, model.ImagePath.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                       using( var fileStream=new FileStream(Path.Combine(filePath,fileName+fileExtention),FileMode.Create))
                       {
                            file.CopyTo(fileStream);
                       }
                    model.ImagePath = @"images\ContentImages\" + fileName + fileExtention;



                }

                if (model.Id==0)
                {
                    model.CreatedDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    _unitOfWork.Article.Add(model);
                    _unitOfWork.Save();
                    TempData["success"] = "Successfully Created";
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    model.ModifiedDate = DateTime.Now;
                    _unitOfWork.Article.Update(model);
                    _unitOfWork.Save();
                    TempData["success"] = "Successfully Created";
                    return RedirectToAction("Index");
                }
            }




            return View();
        }

        #region API Call

        [HttpGet]
        public IActionResult GetAll()
        { 
           var articleList= _unitOfWork.Article.GetAll(includeProperties:"Category");

            return Json(new {data= articleList });
        }

        [HttpPost]
        public IActionResult Delete()
        {


            return View();
        }

        [HttpGet]
        public IActionResult LoadSubCategory(int id)
        {
            var subCategory = _unitOfWork.SubCategory.Where(id);
            
            return Json(new {data= subCategory });
        }

        public IActionResult GetSubCategoryById(int id)
        {
            var subCategory=_unitOfWork.SubCategory.GetFirstOrDefault(x=>x.Id== id);
            return Json(new {data= subCategory});
        }
        #endregion
    }
}
