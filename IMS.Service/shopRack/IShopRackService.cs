using IMS.ClientEntity.shop;
using IMS.ClientEntity.shopRack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopRack
{
    public interface IShopRackService
    {
        Task<bool> Create(ShopRackRequest request, string toekn);
        Task<List<ShopRackResponse>> GetAll(int page, int pageSize);
    }
}
