using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using PassMultipleComplex.Models;

namespace PassMultipleComplex.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50831/");

            ArrayList paramList = new ArrayList();

            Product product = new Product() {ProductId = 1, Category = "Fruit", Name = "Orange", Price = 12};
            Supplier supplier = new Supplier() {SupplierId = 1, Name = "AT", Address = "Unitech"};

            paramList.Add(product);
            paramList.Add(supplier);

            //var result = client.PostAsJsonAsync("api/product/complex", paramList);
            var result = client.PutAsJsonAsync("api/product/complex", paramList);
            HttpResponseMessage response = result.Result;



            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Data = response;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.data = Repository.products;

            return View();
        }
    }
}
