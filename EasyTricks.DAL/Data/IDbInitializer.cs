
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Data
{
    public interface IDbInitializer
    {
        void seed();
        IEnumerable<IdentityRole> GetAllRole();
        IEnumerable<IdentityUser> GetAllUser();
        Task<IdentityUser> GetUserById(string id);
        void AssignRole(IdentityUser user,string role);
        
    }
}
