using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BookStore.Model;
using BookStore.Bll;

namespace BookStore.Api.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/book
        [HttpGet]
        public IList<Books> Get()
        {
            var books = new BooksService().GetAll();
            return books.ToList();
        }

        // GET: api/book/{id}
        [HttpGet]
        public Books Get([FromUri] int id)
        {
            return new Books
            {
                BookId = id,
                Authors = "test author",
                Title = "test title",
                Price = 12.45m
            };
        }
    }
}
