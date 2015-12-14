using System;
using System.Collections.Generic;
using System.Linq;
using SapPro.Entity;
using System.Threading.Tasks;

namespace SapPro.DAL
{
    public class ProductRepository : IProductRepository
    {
        private SapProContext db;
        public ProductRepository(SapProContext _db)
        {
            db = _db;
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.tblProduct.AsEnumerable();
        }

        public IEnumerable<Product> GetProduct(string filterCategory)
        {
            return db.tblProduct.Where(x => x.Category == filterCategory || string.IsNullOrEmpty(filterCategory));
            
        }

        public void AddProduct(Product product)
        {
            db.tblProduct.Add(product);
        }

        public void DeleteProduct(int id)
        {
            Product product = db.tblProduct.Find(id);
            db.tblProduct.Remove(product);

        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
