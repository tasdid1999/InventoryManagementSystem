using Ecom.Service.Token;
using IMS.ClientEntity.shopBin;
using IMS.ClientEntity.shopRow;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopBin
{
    public class ShopBinService : IShopBinService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopBinService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(ShopBinRequest request, string token)
        {
            var createBy = JwtTokenFactory.GetUserIdFromToken(token);

            var dbShopBin = new ShopBin { Name = request.Name, Capacity = request.Capacity, ShopRowId = request.ShopRowId, CreatedAt = DateTime.Now, CreatedBy = createBy, StatusId = 1 };

            await _unitOfWork.ShopBinRepository.Create(dbShopBin);

            return await _unitOfWork.SaveChangeAsync();

        }

        public async Task<List<ShopBinResponse>> GetAll(int page, int pageSize)
        {
            var bins = await _unitOfWork.ShopBinRepository.GetAll(page, pageSize);
            var listOfBin = new List<ShopBinResponse>();
            foreach (var bin in bins)
            {
                listOfBin.Add(new ShopBinResponse { Name = bin.Name, Capacity = bin.Capacity , ShopRowId = bin.ShopRowId });
            }

            return listOfBin;
        }
    }
}

