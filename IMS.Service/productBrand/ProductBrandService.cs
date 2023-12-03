using Ecom.Service.Token;
using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.ProductResponse;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.productBrand
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductBrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(ProductBrandRequest brand,string token)
        {
            var createdBy = JwtTokenFactory.GetUserIdFromToken(token);

            var productBrand = new ProductBrand { Name = brand.Name , CreatedAt = DateTime.Now,CreatedBy = createdBy,StatusId = 1};

            await _unitOfWork.ProductBrandRepository.Create(productBrand);

            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ProductBrandResponse>> GetAllBrand(int page , int pageSize)
        {
            var result = await _unitOfWork.ProductBrandRepository.GetAll(page,pageSize);
            var listOfBrand = new List<ProductBrandResponse>();

            foreach (var item in result)
            {
                listOfBrand.Add(new ProductBrandResponse() {Id = item.Id, BrandName = item.Name });
            }

            return listOfBrand;
        }

        public async Task<bool> IsExist(string BrandName)
        {
            return await _unitOfWork.ProductBrandRepository.IsExist(BrandName);
        }
    }
}
