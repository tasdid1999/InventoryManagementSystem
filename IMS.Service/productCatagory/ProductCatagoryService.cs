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

namespace IMS.Service.productCatagory
{
    public class ProductCatagoryService : IProductCatagoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductCatagoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(ProductCatagoryRequest catagory, string token)
        {
            var createdBy = JwtTokenFactory.GetUserIdFromToken(token);

            var productCatagory = new ProductCatagory { Name = catagory.Name, CreatedAt = DateTime.Now, CreatedBy = createdBy, StatusId = 1 };

            await _unitOfWork.ProductCatagoryRepository.Create(productCatagory);

            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ProductCatagoryResponse>> GetAll(int page , int pageSize)
        {
            var result = await _unitOfWork.ProductCatagoryRepository.GetAll(page,pageSize);
            var listOfCatagory = new List<ProductCatagoryResponse>();

            foreach (var item in result)
            {
                listOfCatagory.Add(new ProductCatagoryResponse() {Id = item.Id, CatagoryName = item.Name });
            }

            return listOfCatagory;
        }

        public Task<bool> IsExist(string catagoryName)
        {
            return _unitOfWork.ProductCatagoryRepository.IsExist(catagoryName);
        }
    }
}
