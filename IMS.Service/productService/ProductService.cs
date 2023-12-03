using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.ProductResponse;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.productService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(ProductRequest product)
        {
            var dbProduct = new Product { Name = product.Name, ProductBrandId = product.BrandId, ProductCatagoryId = product.CatagoryId, CreatedAt = DateTime.Now, CreatedBy = 1, StatusId = 1 };

            var dbPrice = new ProductPrice { Product = dbProduct, price = product.Price, CreatedBy = 1, CreatedAt = DateTime.Now, StatusId = 1 };

            await _unitOfWork.ProductPriceRepository.Create(dbPrice);

            return await _unitOfWork.SaveChangeAsync();


        }
        public Task<List<ProductResponse>> GetAll(int page , int pageSize)
        {
            return _unitOfWork.ProductRepository.GetAll(page, pageSize);
        }
    }
}
