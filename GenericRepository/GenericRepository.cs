using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using NepConfess.Data;

namespace NepConfess.GenericRepository
{
   
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       
         private readonly ApplicationDbContext _context;
    public GenericRepository(ApplicationDbContext context )
    {
       
        _context = context;
    }
        public void Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
           
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public List<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}