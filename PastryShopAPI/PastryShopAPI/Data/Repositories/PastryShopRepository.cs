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

        public void CreateProduct(ProductEntity newCategory)
        {
            _dbContext.Categories.Add(newCategory);
        }

        public async Task CreateProductAsync(long categoryId)
        {
            var categoryToDelete = await _dbContext.Categories.FirstAsync(c => c.Id == categoryId);
            _dbContext.Categories.Remove(categoryToDelete);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsAsync(string orderBy = "Id")
        {
            IQueryable<ProductEntity> query = _dbContext.Categories;
            query = query.AsNoTracking();

            switch (orderBy.ToLower())
            {
                case "name":
                    query = query.OrderBy(c => c.Name);
                    break;
                case "price":
                    query = query.OrderBy(c => c.Price);
                    break;
                /*case "flavors":
                    query = query.OrderBy(c => c.Flavors);
                    break;*/
                default:
                    query = query.OrderBy(c => c.Id);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task UpdateProductAsync(long categoryId, ProductEntity updatedCategory)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            category.Name = updatedCategory.Name ?? category.Name;
            category.Description = updatedCategory.Description ?? category.Description;
            category.ImageUrl = updatedCategory.ImageUrl ?? category.ImageUrl;
            category.Price = updatedCategory.Price ?? category.Price;
            // category.Flavors = updatedCategory.Flavors ?? category.Flavors;
        }
        public async Task<ProductEntity> GetProductAsync(long categoryId)
        {
            IQueryable<ProductEntity> query = _dbContext.Categories;
            query = query.AsNoTracking();
            //query = query.Include(t => t.Players);
            return await query.FirstOrDefaultAsync(c => c.Id == categoryId);

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
