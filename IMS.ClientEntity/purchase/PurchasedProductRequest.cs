using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.purchase
{
    public  class PurchasedProductRequest
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

    }
}
