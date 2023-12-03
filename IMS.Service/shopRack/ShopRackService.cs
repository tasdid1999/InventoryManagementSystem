using Ecom.Service.Token;
using IMS.ClientEntity.shopRack;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopRack
{
    public class ShopRackService : IShopRackService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopRackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(ShopRackRequest request, string token)
        {
            var createdBy = JwtTokenFactory.GetUserIdFromToken(token);

            var shopRack = new ShopRack { Name = request.Name,NumberOfRow = request.NumberOfRow, ShopId = request.ShopId, CreatedAt = DateTime.Now, CreatedBy = createdBy, StatusId = 1 };
            await _unitOfWork.ShopRackRepository.Create(shopRack);

            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<List<ShopRackResponse>> GetAll(int page, int pageSize)
        {
            var racks =  await _unitOfWork.ShopRackRepository.GetAll(page, pageSize);

            var listOfRack = new List<ShopRackResponse>();

            foreach(var rack in racks)
            {
                listOfRack.Add(new ShopRackResponse { ShopId = rack.ShopId, Name = rack.Name,NumberOfRow = rack.NumberOfRow });
            }

            return listOfRack;
        }
    }
}
