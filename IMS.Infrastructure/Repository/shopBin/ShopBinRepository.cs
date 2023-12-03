using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopBin
{
    internal class ShopBinRepository : IShopBinRepository
    {
        private readonly Context _context;

        public ShopBinRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(ShopBin shopBin)
        {
            await _context.AddAsync(shopBin);
        }

        public async Task<List<ShopBin>> GetAll(int page, int pageSize)
        {
            return await _context.shopsBin
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        }
    }
}
