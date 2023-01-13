using EasyTricks.Models.AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public ISubCategoryRepository SubCategory { get; }
        public IArticleRepository  Article { get; }
        void Save();
    }
}
