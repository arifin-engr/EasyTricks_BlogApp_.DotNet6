using Microsoft.AspNetCore.Identity;
using EasyTricks.DAL.Data;
using EasyTricks.Models.AppVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EasyTricks.DAL.Repositories.IRepositories;

namespace EasyTricks.UI.Areas.Admin
{
    [Area("Admin")]
    
    public class AccessManagers : Controller
    {

        //private readonly ApplicationDbContext _db;
          private readonly IDbInitializer _db;
          private readonly IUnitOfWork _unitOfWork;

        public AccessManagers(IDbInitializer db, IUnitOfWork unitOfWork)
        {
            _db= db;
            _unitOfWork= unitOfWork;
            
           
        }
        public IActionResult UserList()
        {


            return View();
        }
        public async  Task<IActionResult> UserManager(string id)
        {
            IdentityUser user = await _db.GetUserById(id);
            //List<IdentityRole> roleList = new List<IdentityRole>();
            var roles= _db.GetAllRole().ToList();
            //var user = await _userManager.FindByIdAsync(id);
            //var user = await _db.Users.FirstOrDefaultAsync(x=>x.Id==id);
            UserManagerVM userManagerVM = new()
            {
                User = user,
                Roles= roles.Select(i=> new SelectListItem
                {
                    Text=i.Name,
                    Value=i.Name
                })
            };


            return View(userManagerVM);
        }
        [HttpPost]
        public async Task< IActionResult> UserManager(UserManagerVM obj)
        {
            IdentityUser user = await _db.GetUserById(obj.User.Id);
            if (ModelState.IsValid)
            {
                
                _db.AssignRole(user, obj.Role);
                _unitOfWork.Save();
                return RedirectToAction("UserList");
            }
            return View(obj);
        }
        public IActionResult UpsertRole()
        {
            return View();
        }
        public IActionResult RoleManager()
        {
            return View();
        }

        #region API Call
        [HttpGet]
        public IActionResult GetAllUser() 
        { 

            var userList=_db.GetAllUser().ToList();
            return Json(new {data=userList});
        }
        [HttpGet]
        public IActionResult GetAllRole()
        {

            var roleList = _db.GetAllRole().ToList();
            return Json(new { data = roleList });
        }
        #endregion
    }
}
