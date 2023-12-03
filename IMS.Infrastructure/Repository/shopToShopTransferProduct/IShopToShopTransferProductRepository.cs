using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopToShopTransferProduct
{
    public interface IShopToShopTransferProductRepository
    {
        Task Create(List<ShopToShopTransferProduct> shopToShopTransferProduct);
    }
}
