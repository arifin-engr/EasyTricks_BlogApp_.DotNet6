using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EasyTricks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async void seed()
        {

            string role = "Super Admin";
            role.Trim();
            var roleExist = _roleManager.RoleExistsAsync(role).Result;
            // Create defult roles
            if (!roleExist)
            {
                _roleManager.CreateAsync(new IdentityRole(role)).GetAwaiter().GetResult();
            }

            //Create User

            const string _userName = "sa";
            const string _password = "555555";
            const string _email = "admin@gmail.com";
           
            _userName.Trim();
            _password.Trim();
            _email.Trim();


            var FindUser = _db.Users.FirstOrDefaultAsync(u => u.UserName == _userName).Result;


            //IdentityResult result;

            if (FindUser == null)
            {

                IdentityUser appUser = new IdentityUser();
                appUser.UserName = _userName;
                appUser.Email = _email;
                appUser.EmailConfirmed = true;
              

                //    //_userManager = new UserManager<AppUser>();
                IdentityResult result = _userManager.CreateAsync(appUser, _password).Result;

                if (result.Succeeded)
                {
                    // AppUser user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == _userName);


                    //        // Adding Manager role 
                    IdentityResult DefultRoleresult = _userManager.AddToRoleAsync(appUser, role).Result;

                    if (DefultRoleresult.Succeeded)
                    {
                        _db.SaveChanges();
                    }
                }
            }
        }
    }
}
