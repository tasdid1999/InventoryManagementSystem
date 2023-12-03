using IMS.ClientEntity.shopToshopTransfer;
using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopToShopTransfer
{
    public interface IShopToShopTransferRepository
    {
        Task Create(ShopToShopTransfer shopToShopTransfer);

        Task<List<ShopToShopTransferResponse>> GetAll(int page , int pageSize);

        Task<ShopToShopTransferDetailsResponse> GetById(int id);
    }
}
