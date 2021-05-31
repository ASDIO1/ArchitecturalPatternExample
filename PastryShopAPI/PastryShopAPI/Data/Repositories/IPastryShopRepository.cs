using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI
{
    public interface IPastryShopRepository
    {
        //teams
        public Task<IEnumerable<ProductEntity>> GetProductsAsync(string orderBy = "Id");
        public Task<ProductEntity> GetProductAsync(long categoryId);
        public void CreateProduct(ProductEntity newCategory);
        public Task CreateProductAsync(long categoryId);
        public Task UpdateProductAsync(long categoryId, ProductEntity updatedCategory);

        Task<bool> SaveChangesAsync();
    }
}
