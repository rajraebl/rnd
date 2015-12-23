using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using ExceptionHandling.Filters;

namespace ExceptionHandling.Controllers
{
    public class HomeController : ApiController
    {
        private List<Product> Products = new List<Product>();

        public HomeController()
        {
            for (int i = 0; i < 6; i++)
            {
             Products.Add(new Product(){Id = i, Name = "Product_" + i});   
            }
        }

        // GET api/default1
        public IEnumerable<Product> Get()
        {
            return Products;
        }

         //GET api/default1/5
        //You can override the action name by using the ActionName attribute.Without this attribute ur method will b accessible via c#method name only. 
        //for support of action name u need another routing with {action} parameter
        //[ActionName("GetById")]
        //public Product GetProduct(int id)
        //{
        //    var product = Products.Single(x => x.Id == id);
        //    if (product == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    return product;
        //}

        //To prevent a method from getting invoked as an action, use the NonAction attribute. This signals to the framework that the method is not an action, even if it would otherwise match the routing rules
        //[NonAction]
        public Product Get(int id)
        {
            var product = Products.Single(x => x.Id == id);
            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with id={0}", id))
                };
                throw new HttpResponseException(resp);
            }
            return product;
        }

        //u can call this by specifying querystring only api/home/?ola=true
        public string Get(bool ola)
        {
            return "thevalue of loa is=" + ola;
        }


        /*
         without exception filter thsi will result in 500 error code i.e internaml server error
         */
        // POST api/default1
        [NotImplementedFilter]
        public Product Post()
        {
            throw new NotImplementedException("This methos ia not implmntd");
        }

        // PUT api/default1/5
        [BasicAuthorizeAttribute]

        public HttpResponseMessage Put()
        {
            // you can call this method from postman by setting the key as Authorization and value as Basic b2xhOnBvbGE=
            // we converted ola:pola to b2xhOnBvbGE= via  https://www.base64encode.org/
            return Request.CreateResponse(HttpStatusCode.OK,"HE is genuine user His anme is:" +Thread.CurrentPrincipal.Identity.Name);
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
