using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Data.Repositories
{
    public class PastryShopRepository : IPastryShopRepository
    {
        private PastryShopDbContext _dbContext;

        public PastryShopRepository(PastryShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateProduct(ProductEntity newProduct)
        {
            _dbContext.Products.Add(newProduct);
        }

        public async Task CreateProductAsync(long productId)
        {
            var productToDelete = await _dbContext.Products.FirstAsync(c => c.Id == productId);
            _dbContext.Products.Remove(productToDelete);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsAsync(string orderBy = "Id")
        {
            IQueryable<ProductEntity> query = _dbContext.Products;
            query = query.AsNoTracking();

            switch (orderBy.ToLower())
            {
                case "name":
                    query = query.OrderBy(c => c.Name);
                    break;
                case "price":
                    query = query.OrderBy(c => c.Price);
                    break;
                default:
                    query = query.OrderBy(c => c.Id);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task UpdateProductAsync(long productId, ProductEntity updatedProduct)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            product.Name = updatedProduct.Name ?? product.Name;
            product.Description = updatedProduct.Description ?? product.Description;
            product.ImageUrl = updatedProduct.ImageUrl ?? product.ImageUrl;
            product.Price = updatedProduct.Price ?? product.Price;
        }
        public async Task<ProductEntity> GetProductAsync(long productId)
        {
            IQueryable<ProductEntity> query = _dbContext.Products;
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(c => c.Id == productId);

            //hit to database
            //tolist()
            //toArray()
            //foreach
            //firstOfDefaul
            //Single
            //Count
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var res = await _dbContext.SaveChangesAsync();
                return res > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
