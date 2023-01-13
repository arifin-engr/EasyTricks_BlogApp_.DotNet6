using EasyTricks.DAL.Data;
using EasyTricks.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db=db;
            Category = new CategoryRepository(_db);
            SubCategory = new SubCategoryRepository(_db);
            Article = new ArticleRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }

        public IArticleRepository Article { get; private set; }

        public ISubCategoryRepository SubCategory { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
