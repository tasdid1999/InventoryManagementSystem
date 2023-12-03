using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.productPrice
{
    public class ProductPriceRepository : IProductPriceRepository
    {
        private readonly Context _context;

        public ProductPriceRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(ProductPrice price)
        {
            await _context.ProductPrice.AddAsync(price);
        }

        public async Task<List<ProductPrice>> GetAll()
        {
            return await _context.ProductPrice.ToListAsync();
        }
    }
}
