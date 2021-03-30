using SICSinop.Domain.Entities;
using SICSinop.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BasicEntity
    {
        protected readonly DbContext MainContext;

        protected readonly DbSet<T> dbSetEntity;

        public Repository(DbContext context)
        {
            MainContext = context;
            dbSetEntity = MainContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbSetEntity;
        }

        public T FindById(int id)
        {
            return (T)GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        public T Create(T entity)
        {
            dbSetEntity.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            dbSetEntity.Update(entity);
            return entity;
        }

        public void Create(IEnumerable<T> list)
        {
            dbSetEntity.AddRange();
        }

        public T Remove(T entity)
        {
            dbSetEntity.Remove(entity);
            return entity;
        }

        public void SaveChanges()
        {
            MainContext.SaveChanges();
        }
    }
}
