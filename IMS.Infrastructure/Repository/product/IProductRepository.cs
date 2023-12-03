using IMS.ClientEntity.ProductResponse;
using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.product
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task<List<ProductResponse>> GetAll(int page , int pageSize);
    }
}
