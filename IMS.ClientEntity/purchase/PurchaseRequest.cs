using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.purchase
{
    public class PurchaseRequest
    {
       
        public int ShopId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public List<PurchasedProductRequest> PurchasedProducts { get; set; }

    }
}
