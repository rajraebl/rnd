using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SapPro.Entity;
using SapPro.DAL;

namespace SapPro.Service.ProductCatalog.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository repo;
        public ProductController(IProductRepository _repository)
        {
            repo = _repository;
        }
        // GET api/Product
        public IEnumerable<Product> GetProducts()
        {
            return repo.GetProducts();
        }

        // GET api/Product/5
        public IEnumerable< Product> GetProduct(string filterCategory)
        {
            var products = repo.GetProduct(filterCategory);
            if (products == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return products;
        }


        // POST api/Product
        public HttpResponseMessage PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                repo.AddProduct(product);
                repo.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, product);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Product/5
        public HttpResponseMessage DeleteProduct(int id)
        {
            repo.DeleteProduct(id);

            try
            {
                repo.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}