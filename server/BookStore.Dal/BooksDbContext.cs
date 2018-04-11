using BookStore.Model;

namespace BookStore.Dal
{
    class BooksDbContext 
        : BaseDbContext<Books>, IBaseDbContext<Books>
    {
    }
}
