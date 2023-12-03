using IMS.ClientEntity.shopBin;
using IMS.ClientEntity.shopRack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopBin
{
    public interface IShopBinService
    {
        Task<bool> Create(ShopBinRequest request, string toekn);
        Task<List<ShopBinResponse>> GetAll(int page, int pageSize);
    }
}
