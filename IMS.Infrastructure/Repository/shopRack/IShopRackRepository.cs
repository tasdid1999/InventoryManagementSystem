using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopRack
{
    public interface IShopRackRepository
    {
        Task Create(ShopRack shopRack);
        Task<List<ShopRack>> GetAll(int page, int pageSize);
    }
}
