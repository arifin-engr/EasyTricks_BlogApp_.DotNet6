﻿using EasyTricks.DAL.Data;
using EasyTricks.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyTricks.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly ApplicationDbContext _db;
        internal DbSet<T> _dbset;
        public Repository(ApplicationDbContext db) 
        { 
            _db= db;
            _dbset= _db.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
           
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbset;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbset;
             query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        public void RemoveRange(List<T> entity)
        {
           _dbset.RemoveRange(entity);
        }
    }
}
