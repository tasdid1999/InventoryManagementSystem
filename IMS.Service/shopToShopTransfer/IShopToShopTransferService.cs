using IMS.ClientEntity.shopToshopTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopToShopTransfer
{
    public interface IShopToShopTransferService
    {
        Task<bool> Create(ShopToShopTransferRequest request,string token);

        Task<List<ShopToShopTransferResponse>> GetAll(int page , int pageSize);

        Task<ShopToShopTransferDetailsResponse> GetById(int id);
    }
}
