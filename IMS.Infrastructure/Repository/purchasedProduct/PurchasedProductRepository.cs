using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using IMS.Infrastructure.Repository.purchaseDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.purchasedProduct
{
    public class PurchasedProductRepository : IPurchasedProductRepository
    {
        private readonly Context _context;
        private readonly SqlConnectionFactory _sqlConnectionFactory;
        public PurchasedProductRepository(Context context, SqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task Create(List<PurchasedProduct> purchasedProducts)
        {
            await _context.purchasedProducts.AddRangeAsync(purchasedProducts);  
        }
    }
}
