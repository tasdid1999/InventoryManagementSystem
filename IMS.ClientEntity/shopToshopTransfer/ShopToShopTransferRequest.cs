using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.shopToshopTransfer
{
    public class ShopToShopTransferRequest
    {
        public int FromShopId { get; set; }

        public int ToShopId { get; set; }

        public List<ShopToShopProductRequest> Products { get; set; }
    }
}
