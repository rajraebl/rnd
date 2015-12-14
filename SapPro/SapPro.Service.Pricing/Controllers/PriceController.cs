using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SapPro.DAL;

namespace SapPro.Service.Pricing.Controllers
{
    public class PriceController : ApiController
    {
        private IPriceRepository repo;

        public PriceController(IPriceRepository _repo)
        {
            repo = _repo;
        }
        public IEnumerable<  decimal> GetProduct(string filterCategory)
        //public decimal GetProduct(string filterCategory)
        {
            decimal price;
            try
            {
                price = repo.GetPrice(filterCategory);

            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            IList<decimal> dd = new List<decimal>() {price};
            return dd;
        }
    }
}
