using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopRow
{
    public interface IShopRowRepository
    {
        Task Create(ShopRow shopRow);
        Task<List<ShopRow>> GetAll(int page, int pageSize);
    }
}
