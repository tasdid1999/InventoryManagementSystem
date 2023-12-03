using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopRack
{
    public class ShopRackRepository : IShopRackRepository
    {
        private readonly Context _context;

        public ShopRackRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(ShopRack shopRack)
        {
            await _context.AddAsync(shopRack);
        }

        public async Task<List<ShopRack>> GetAll(int page, int pageSize)
        {
            return await _context.shopsRack
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        }
    }
}
