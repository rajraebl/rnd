using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassMultipleComplex.Models
{
    public interface IRepository
    {
        Product AddProduct(Product item);
    }
    public class Repository : IRepository
    {
        public static List<Product> products = new List<Product>()
        {
            new Product() {ProductId = 1, Category = "Fruit", Name = "Orange", Price = 12},
            new Product() {ProductId = 2, Category = "Fruit", Name = "Grapes", Price = 1},
            new Product() {ProductId = 3, Category = "Fruit", Name = "Mango", Price = 119}
        };

        public Product AddProduct(Product item)
        {
            products.Add(item);
            return item;
        }


    }
}