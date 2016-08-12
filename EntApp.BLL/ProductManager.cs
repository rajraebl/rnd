using AutoMapper;
using EntApp.DAL;
using EntApp.DAL.Custom;
using EntApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntApp.BLL
{
    public class ProductManager:IProductManager
    {
        private readonly UnitOfWork unitOfWork;
        public ProductManager()
        {
            unitOfWork = new UnitOfWork();
        }
        public IEnumerable<Entity.ProductEntity> GetProduct()
        {
            //We have decided not to expose our db entities to Web API project for security concerns, so we need something to map the db entities data to my business entity classes.
            var products = unitOfWork.ProductRepo.Get().ToList();

            //Create Map in memory
            Mapper.CreateMap<Product, ProductEntity>();

            //Using that map, try to map FromList to Tolist using source
            var productModel = Mapper.Map< List< Product>,List< ProductEntity>>(products);
            return productModel;
        }

        public Entity.ProductEntity GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public int CreateProduct(Entity.ProductEntity obj)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Entity.ProductEntity obj)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
