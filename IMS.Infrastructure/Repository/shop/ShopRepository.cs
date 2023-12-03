using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shop
{
    public class ShopRepository : IShopRepository
    {
        private readonly Context _context;

        public ShopRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(Shop shop)
        {
           await _context.AddAsync(shop);
        }

        public async Task<List<Shop>> GetAll(int page , int pageSize)
        {
            return await _context.shops
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        }
    }
}
