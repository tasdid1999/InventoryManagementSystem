using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.purchaseDetails
{
    public interface IPurchasedProductRepository
    {
        Task Create(List<PurchasedProduct> purchasedProducts);
    }
}
