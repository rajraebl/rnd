using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using PassMultipleComplex.Models;

namespace PassMultipleComplex.Controllers
{
    public class productController : ApiController
    {
        [HttpPut]
        public HttpResponseMessage SuppProd(ArrayList arrayList) // u can also utilise JArray here
        {
            HttpResponseMessage response;

            //JArray j = new JArray(); //  it is array of JSON objects provided by Newtonsoft
            
            if (arrayList.Count > 0)
            {
                //Summary: //     Deserializes the JSON to the specified .NET type.
                //
                // Parameters:
                //   value:
                //     The JSON to deserialize.
                Product p = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(arrayList[0].ToString());

                Supplier s = Newtonsoft.Json.JsonConvert.DeserializeObject<Supplier>(arrayList[1].ToString());

                response = new HttpResponseMessage(HttpStatusCode.Created);

            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        [HttpPost]
        
        public HttpResponseMessage AddProduct(Product p)
        {
            IRepository r = new Repository();
            r.AddProduct(p);
            return new HttpResponseMessage(HttpStatusCode.Created);

        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Repository.products;

        }

    }
}
