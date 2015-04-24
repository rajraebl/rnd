using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class Default1Controller : ApiController
    {
        Book[] Books = new Book[]
        {
            new Book{Id = 1,Name="Apple", Type="Fruit", Cost=100},
            new Book{Id = 2,Name="Tomato",Type="vasitable",Cost=50},
            new Book {Id = 3,Name="T-Shirt",Type="cloths",Cost=500}
        };

        // GET api/default1
        public IEnumerable<Book> Get()
        {
            return Books;
        }

        // GET api/default1/5
        public Book Get(int id)
        {
            return Books.FirstOrDefault(x=>x.Id==id);
        }

        // POST api/default1
        public void Post([FromBody]string value)
        {
        }

        // PUT api/default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
        }
    }
}
