using EntApp.Entity;
using System.Collections.Generic;


namespace EntApp.BLL
{
    public interface IProductManager
    {
        IEnumerable<ProductEntity> GetProduct();
        
        ProductEntity GetProductById(int Id);

        int CreateProduct(ProductEntity obj);

        bool UpdateProduct(ProductEntity obj);
        
        bool DeleteProduct(int Id);

    }
}
