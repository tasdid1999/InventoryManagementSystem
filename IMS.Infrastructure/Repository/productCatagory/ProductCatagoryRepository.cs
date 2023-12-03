using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.productCatagory
{
    public class ProductCatagoryRepository : IProductCatagoryRepository
    {
        private readonly Context _context;

        public ProductCatagoryRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(ProductCatagory catagory)
        {
            await _context.AddAsync(catagory);
        }

        public async Task<List<ProductCatagory>> GetAll(int page , int pageSize)
        {
            return await _context.ProductCatagory
                                 .Skip((page-1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<bool> IsExist(string catagoryName)
        {
           return await _context.ProductCatagory.Where(x => x.Name.ToLower().Equals(catagoryName.ToLower())).AnyAsync();

        }
    }
}
