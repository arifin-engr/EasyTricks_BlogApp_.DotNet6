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
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticleRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
        public void Update(Article entity)
        {
            var article=_db.Articles.FirstOrDefault(entity=>entity.Id==entity.Id);
            if (article!=null) 
            {
                article.Title = entity.Title;
                article.Description = entity.Description;
                article.Author = entity.Author;
                article.ModifiedDate = entity.ModifiedDate;
                if (entity.ImagePath!=null)
                {
                    article.ImagePath = entity.ImagePath;
                }
            }
        }
    }
}
