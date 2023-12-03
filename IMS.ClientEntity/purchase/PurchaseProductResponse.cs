using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.purchase
{
    public class PurchaseProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductBrandName { get; set; }

        public decimal PurchasedPrice { get; set; }  

        public decimal PurchasedQuantity { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
