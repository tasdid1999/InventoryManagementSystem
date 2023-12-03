using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.productBrand
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly Context _context;

        public ProductBrandRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(ProductBrand brand)
        {
            await _context.ProductBrand.AddAsync(brand);
        }

        public async Task<List<ProductBrand>> GetAll(int page , int pageSize)
        {
            return await _context.ProductBrand
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<bool> IsExist(string BrandName)
        {
           return  await _context.ProductBrand.Where(x => x.Name.ToLower() == BrandName.ToLower()).AnyAsync();
        }
    }
}
