using Ecom.Service.Token;
using IMS.ClientEntity.shop;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shop
{
    public class ShopService : IShopService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(ShopRequest request,string token)
        {
            var createdBy = JwtTokenFactory.GetUserIdFromToken(token);

            var shop = new Shop { Name = request.Name ,Address = request.Address,CreatedAt = DateTime.UtcNow,CreatedBy = createdBy,StatusId = 1};
            await _unitOfWork.ShopRepository.Create(shop);

            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ShopResponse>> GetAll(int page, int pageSize)
        {
           var shops = await _unitOfWork.ShopRepository.GetAll(page, pageSize);
           
           var listOfShop = new List<ShopResponse>();

            foreach (var shop in shops)
            {
                listOfShop.Add(new ShopResponse { Name = shop.Name, Address = shop.Address });
            }

            return listOfShop;
           
        }
    }
}
