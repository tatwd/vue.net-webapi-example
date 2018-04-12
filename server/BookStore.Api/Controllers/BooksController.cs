using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BookStore.Model;
using BookStore.Bll;
using Newtonsoft.Json;

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
        [Route("api/books/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var book = new BooksService()
                .GetModel(x => x.BookId == id)
                .SingleOrDefault();

            HttpResponseMessage response = new HttpResponseMessage();

            // config response content
            response.Content = 
                new StringContent(JsonConvert.SerializeObject(book));
            
            // config response content type
            response.Content.Headers.ContentType = 
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return response;
        }

        [HttpPut]
        [Route("api/books/{id}")]
        public string Put(int id)
        {
            return $"put {id}";
        }

        [HttpDelete]
        [Route("api/books/{id}")]
        public string Delete(int id)
        {
            return $"delete {id}";
        }
    }
}
