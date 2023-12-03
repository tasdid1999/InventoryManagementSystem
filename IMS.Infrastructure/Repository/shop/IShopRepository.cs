using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Entity.Domain;

namespace IMS.Infrastructure.Repository.shop
{
    public interface IShopRepository
    {
        Task Create(Shop shop);
        Task<List<Shop>> GetAll(int page , int pageSize);

    }
}
