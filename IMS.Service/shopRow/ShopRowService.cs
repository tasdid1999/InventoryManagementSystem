using Ecom.Service.Token;
using IMS.ClientEntity.shopRow;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopRow
{
    public class ShopRowService : IShopRowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopRowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(ShopRowRequest request, string token)
        {
            var createBy = JwtTokenFactory.GetUserIdFromToken(token);

            var shopRow = new ShopRow { Name = request.Name,NumberOfBin= request.NumberOfBin,ShopRackId = request.ShopRackId,CreatedAt = DateTime.Now,CreatedBy = createBy,StatusId = 1 };
           
            await _unitOfWork.ShopRowRepository.Create(shopRow);

            return await _unitOfWork.SaveChangeAsync();

        }

        public async Task<List<ShopRowResponse>> GetAll(int page, int pageSize)
        {
            var rows = await _unitOfWork.ShopRowRepository.GetAll(page, pageSize);
            var listOfRow = new List<ShopRowResponse>();
            foreach(var row in rows)
            {
                    listOfRow.Add(new ShopRowResponse { Name = row.Name , NumberOfBin = row.NumberOfBin , ShopRackId = row.ShopRackId});
            }

            return listOfRow;
        }
    }
}
