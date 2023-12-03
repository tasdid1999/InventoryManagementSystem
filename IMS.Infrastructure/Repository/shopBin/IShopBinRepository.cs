using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopBin
{
    public interface IShopBinRepository
    {
        Task Create(ShopBin shopBin);
        Task<List<ShopBin>> GetAll(int page, int pageSize);
    }
}
