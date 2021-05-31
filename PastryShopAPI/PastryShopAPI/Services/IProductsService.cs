using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Services
{
    public interface IProductsService
    {
        public Task<IEnumerable<ProductModel>> GetProductsAsync(string orderBy = "Id");
        // public Task<TeamWithPlayerModel> GetTeamAsync(long teamId);
        public Task<ProductModel> GetProductAsync(long productId);
        public Task<ProductModel> CreateProductAsync(ProductModel newProduct);
        public Task<bool> DeleteProductAsync(long productId);
        public Task<ProductModel> UpdateProductAsync(long productId, ProductModel updatedProduct);
    }
}
