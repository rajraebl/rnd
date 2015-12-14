using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SapPro.Entity;

namespace SapPro.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProduct(string filterCategory);

        void AddProduct(Product product);

        void DeleteProduct(int id);

        void SaveChanges();
    }
}
