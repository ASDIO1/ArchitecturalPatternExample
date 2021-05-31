using AutoMapper;
using PastryShopAPI.Exceptions;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Services
{
    public class ProductsService : IProductsService
    {
        private IPastryShopRepository _pastryShopRepository;
        private IMapper _mapper;

        private HashSet<string> _allowedOrderByValues = new HashSet<string>()
        {
            "id",
            "name",
            "price"
        };

        public ProductsService(IPastryShopRepository pastryShopRepository, IMapper mapper)
        {
            _pastryShopRepository = pastryShopRepository;
            _mapper = mapper;
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel newProduct)
        {
            var categoryEntity = _mapper.Map<ProductEntity>(newProduct);
            _pastryShopRepository.CreateProduct(categoryEntity);
            var result = await _pastryShopRepository.SaveChangesAsync();

            if (result)
            {
                return _mapper.Map<ProductModel>(categoryEntity);
            }

            throw new Exception("Database Error");
        }

        public async Task<bool> DeleteProductAsync(long productId)
        {
            await ValidateProductAsync(productId);
            await _pastryShopRepository.CreateProductAsync(productId);
            var result = await _pastryShopRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }
            return true;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync(string orderBy = "Id")
        {
            if (!_allowedOrderByValues.Contains(orderBy.ToLower()))
                throw new InvalidOperationItemException($"The Orderby value: {orderBy} is invalid, please use one of {String.Join(',', _allowedOrderByValues.ToArray())}");
            var entityList = await _pastryShopRepository.GetProductsAsync(orderBy.ToLower());
            var modelList = _mapper.Map<IEnumerable<ProductModel>>(entityList);
            return modelList;
        }

        public async Task<ProductModel> GetProductAsync(long productId)
        {
            var category = await _pastryShopRepository.GetProductAsync(productId);

            if (category == null)
            {
                throw new NotFoundItemException($"The product with id: {productId} does not exists.");
            }


            return _mapper.Map<ProductModel>(category);
        }

        public async Task<ProductModel> UpdateProductAsync(long productId, ProductModel updatedProduct)
        {
            await ValidateProductAsync(productId);// GetTeamAsync(teamId);
            updatedProduct.Id = productId;
            await _pastryShopRepository.UpdateProductAsync(productId, _mapper.Map<ProductEntity>(updatedProduct));
            var result = await _pastryShopRepository.SaveChangesAsync();

            if (!result)
            {
                throw new Exception("Database Error");
            }

            return _mapper.Map<ProductModel>(updatedProduct);
        }

        private async Task ValidateProductAsync(long productId)
        {
            // await GetProductAsync(teamId);
            var category = await _pastryShopRepository.GetProductAsync(productId);

            if (category == null)
            {
                throw new NotFoundItemException($"The product with id: {productId} does not exists.");
            }
        }
    }
}
