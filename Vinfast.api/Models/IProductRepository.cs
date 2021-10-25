using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;

namespace Vinfast.api.Models
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int productid);
        Task<Product> Addproduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(int productid);
        Task<Product> GetProductByName(string name);
        

    }
}
