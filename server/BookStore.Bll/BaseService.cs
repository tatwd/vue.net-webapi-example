using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BookStore.Model;
using BookStore.Dal;

namespace BookStore.Bll
{
    public interface IBaseService<T> where T : class, new()
    {
        bool Add(T t);
        IQueryable<T> GetAll();
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
    }
}
