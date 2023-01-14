using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Repositories.IRepositories
{
    public interface IAccountRepository
    {
        void CreateRole(string roleName);
        void UpadteRole(string roleName);
        void AssignRole(string user,string roleName);
        IEnumerable<AppUser> GetAllUser(string userId);
    }
}
