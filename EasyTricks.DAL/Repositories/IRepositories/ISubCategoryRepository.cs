using EasyTricks.Models.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Repositories.IRepositories
{
    public interface ISubCategoryRepository:IRepository<SubCategory>
    {
        void Update(SubCategory obj);
        List<SubCategory> Where(int id);
    }
}
