
using EasyTricks.DAL.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace EasyTricks.UI.Areas.Admin
{
    [Area("Admin")]
    
    public class AccessManagers : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public AccessManagers()
        {

        }
        public IActionResult UserList()
        {

            return View();
        }
        public IActionResult UserManager()
        {
            return View();
        }
        public IActionResult UpsertRole()
        {
            return View();
        }
        public IActionResult RoleManager()
        {
            return View();
        }
    }
}
