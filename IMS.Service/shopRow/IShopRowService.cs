using IMS.ClientEntity.shopRack;
using IMS.ClientEntity.shopRow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.shopRow
{
    public interface IShopRowService
    {
        Task<bool> Create(ShopRowRequest request, string toekn);
        Task<List<ShopRowResponse>> GetAll(int page, int pageSize);
    }
}
