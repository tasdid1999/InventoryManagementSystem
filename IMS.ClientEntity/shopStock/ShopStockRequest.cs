using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.shopStock
{
    public class ShopStockRequest
    {
        public int ShopId { get; set; }

        public List<ShopStockProductRequest> Products { get; set; }
    }
}
