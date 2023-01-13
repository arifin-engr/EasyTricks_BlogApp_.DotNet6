using EasyTricks.DAL.Data;
using EasyTricks.DAL.Repositories.IRepositories;
using EasyTricks.Models.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryRepository(ApplicationDbContext db):base(db) 
        {
            _db=db;
        }
        public void Update(SubCategory obj)
        {
            var model=_db.SubCategories.FirstOrDefault(x=>x.Id==obj.Id);
            if (model!=null)
            {
                model.Name = obj.Name;
                model.CategoryId = obj.CategoryId;

            }
        }

        public List<SubCategory> Where(int id)
        {
            var itemList=new List<SubCategory>();
            var subCategory=_db.SubCategories.Where(x=>x.CategoryId==id);
            itemList=subCategory.ToList();
            return itemList;
        }
    }
}
