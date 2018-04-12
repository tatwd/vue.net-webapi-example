using BookStore.Dal;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.Bll
{
    public interface IBaseService<T> where T : class, new()
    {
        bool Add(T t);
        IQueryable<T> GetAll();
        IQueryable<T> GetModel(Expression<Func<T, bool>> whereLambda);
    }

    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseDbContext<T> baseDbContext = DbContextFactory<T>.Get();

        public bool Add(T t)
        {
            return baseDbContext.Add(t);
        }

        public IQueryable<T> GetAll()
        {
            return baseDbContext.GetAll();
        }

        public IQueryable<T> GetModel(Expression<Func<T, bool>> whereLambda)
        {
            return baseDbContext.GetModel(whereLambda);
        }
    }
}
