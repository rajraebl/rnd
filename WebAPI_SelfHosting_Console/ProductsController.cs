﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI_SelfHosting_Console
{
    public class ProductsController : ApiController
    {
        public List<Product> GetProducts()
        {
            using (var el = new EventLog("Application"))
            {
                el.Source = "MsiInstaller";
                el.WriteEntry("GetProducts() method called Which is self hosted.MsiInstaller", EventLogEntryType.Error, 1035);
            }

            return new List<Product> 
            {
                new Product() {Id = 1, Name = "Name1", Type = "Type1"},
                new Product() {Id = 2, Name = "Name2", Type = "Type2"}
            };
        }

    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
