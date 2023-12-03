using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.purchase
{
    public class PurchaseResponse
    {
        public int PurchaseId { get; set; }

        public int RequisitionId { get; set; }

        public List<PurchaseProductResponse> PurchasedProducts { get; set; }
    }
}
