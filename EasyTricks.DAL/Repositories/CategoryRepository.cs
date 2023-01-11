using EasyTricks.DAL.Data;
using EasyTricks.DAL.Repositories.IRepositories;
using EasyTricks.Models.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db) 
        {
            _db= db;
        }

        public void Update(Category entity)
        {
           _db.Categories.Update(entity);
        }
    }
}
