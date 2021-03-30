using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T FindById(int id);
        T Create(T entity);
        T Update(T entity);
        void Create(IEnumerable<T> entity);
        T Remove(T entity);
        void SaveChanges();
    }
}
