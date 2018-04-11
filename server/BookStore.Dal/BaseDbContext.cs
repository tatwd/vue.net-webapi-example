using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using BookStore.Model;
using System.Linq.Expressions;

namespace BookStore.Dal
{

    public interface IBaseDbContext<T> where T : class, new()
    {
        bool Add(T t);
        IQueryable<T> GetAll();
        IQueryable<T> GetModel(Expression<Func<T, bool>> whereLambda);
    }

    public abstract class BaseDbContext<T> where T : class, new ()
    {
        DbContext context = new BookStoreEntities();

        public bool Add(T t)
        {
            try
            {
                context.Set<T>().Add(t);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query;

            try
            {
                context.Configuration.ProxyCreationEnabled = false;
                query = context.Set<T>();
            }
            catch (Exception ex)
            {
                query = null;
            }

            return query;
        }

        public IQueryable<T> GetModel(Expression<Func<T, bool>> whereLambda)
        {
            IQueryable<T> query;

            try
            {
                context.Configuration.ProxyCreationEnabled = false;
                query = context.Set<T>().Where(whereLambda);
            }
            catch (Exception)
            {
                query = null;
            }

            return query;
        }
    }
}
