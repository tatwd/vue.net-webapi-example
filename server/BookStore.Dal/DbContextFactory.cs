using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Dal
{
    public static class DbContextFactory<T> where T : class, new()
    {
        public static IBaseDbContext<T> Get()
        {
            Type type = Type.GetType("BookStore.Dal.BooksDbContext");
            return (IBaseDbContext<T>)Activator.CreateInstance(type);
        }
    }
}
