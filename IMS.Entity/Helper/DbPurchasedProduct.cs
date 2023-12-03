using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Helper
{
    public class DbPurchasedProduct
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductBrandName { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal PurchaseQuantity { get; set; }

        public DateTime PurchaseDate { get; set; }
    }
}
