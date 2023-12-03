using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.shopStock
{
    public class ShopStockProductRequest
    {
        public int ProductId { get; set; }

        public int RackId { get; set; }

        public int RowId { get; set; }

        public int BinId { get; set; }

        public decimal Quantity { get; set; }
      
    }
}
