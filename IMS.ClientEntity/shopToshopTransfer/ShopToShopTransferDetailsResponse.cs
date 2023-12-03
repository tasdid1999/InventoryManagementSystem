using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.shopToshopTransfer
{
    public class ShopToShopTransferDetailsResponse
    {
        public int Id { get; set; }
        public string FromShopName { get; set; }

        public string ToShopName { get; set; }

        public virtual List<ShopToShopTransferProductResponse> Products { get; set; }
    }
}
