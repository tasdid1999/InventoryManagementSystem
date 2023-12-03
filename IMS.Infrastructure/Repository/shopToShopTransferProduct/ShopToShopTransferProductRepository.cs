using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopToShopTransferProduct
{
    public class ShopToShopTransferProductRepository : IShopToShopTransferProductRepository
    {
        private readonly Context _context;

        public ShopToShopTransferProductRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(List<ShopToShopTransferProduct> shopToShopTransferProduct)
        {
            await _context.shopToShopTranferProduct.AddRangeAsync(shopToShopTransferProduct);
        }
    }
}
