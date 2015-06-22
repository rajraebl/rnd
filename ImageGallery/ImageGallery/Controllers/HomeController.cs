using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ImageGallery.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;
        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        // GET api/home
        public ActionResult Index()
        {
            return View();
        }

        // GET api/home/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/home
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/home/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/home/5
        //public void Delete(int id)
        //{
        //}
    }
}
