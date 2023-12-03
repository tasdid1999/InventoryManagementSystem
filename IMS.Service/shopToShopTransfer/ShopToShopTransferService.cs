using Ecom.Service.Token;
using IMS.ClientEntity.shopToshopTransfer;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopToShopTransfer
{
    public class ShopToShopTransferService : IShopToShopTransferService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShopToShopTransferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ShopToShopTransferRequest request,string token)
        {
            var createdBy = JwtTokenFactory.GetUserIdFromToken(token);

            var sts = new ShopToShopTransfer { FromShopId  = request.FromShopId , ToShopId = request.ToShopId , CreatedAt = DateTime.Now , CreatedBy = createdBy , StatusId = 1};

            await _unitOfWork.ShopToShopTransferRepository.Create(sts);

            var stsp = new List<ShopToShopTransferProduct>();

            foreach(var item in request.Products)
            {
                stsp.Add(new ShopToShopTransferProduct {ShopToShopTransfer = sts , ProductId = item.ProductId,Quantity = item.Quantity,CreatedAt = DateTime.Now,CreatedBy = createdBy,StatusId = 1 });
            }

            await _unitOfWork.ShopToShopTransferProductRepository.Create(stsp);

            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ShopToShopTransferResponse>> GetAll(int page, int pageSize)
        {
            return await _unitOfWork.ShopToShopTransferRepository.GetAll(page, pageSize); 
        }

        public async Task<ShopToShopTransferDetailsResponse> GetById(int id)
        {
            return await _unitOfWork.ShopToShopTransferRepository.GetById(id);
        }
    }
}
