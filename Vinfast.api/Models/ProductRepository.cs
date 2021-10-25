using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;

namespace Vinfast.api.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products.ToListAsync();
        }
        public async Task<Product> GetProduct(int productid)
        {
            return await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == productid);
        }

        public async Task<Product> Addproduct(Product product)
        {
            var result = await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == product.ProductId);

            if (result != null)
            {
                result.Name = product.Name;
                result.Price = product.Price;
                result.version.VersionId = product.version.VersionId;
                result.PhotoPath = product.PhotoPath;
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
        public async Task<Product> DeleteProduct(int id)
        {
            var result = await appDbContext.Products
                .FirstOrDefaultAsync(e => e.ProductId == id);
            if (result != null)
            {
                appDbContext.Products.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await appDbContext.Products
                .FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
