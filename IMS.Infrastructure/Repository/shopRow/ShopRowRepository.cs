using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopRow
{
    public class ShopRowRepository : IShopRowRepository
    {
        private readonly Context _context;

        public ShopRowRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(ShopRow shopRow)
        {
            await _context.AddAsync(shopRow);
        }

        public async Task<List<ShopRow>> GetAll(int page, int pageSize)
        {
            return await _context.shopsRow
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        }
    }
}
