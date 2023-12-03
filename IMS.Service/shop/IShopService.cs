using IMS.ClientEntity.shop;
using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shop
{
    public interface IShopService
    {
        Task<bool> Create(ShopRequest request,string toekn);
        Task<List<ShopResponse>> GetAll(int page, int pageSize);
    }
}
