using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.productPrice
{
    public interface IProductPriceRepository
    {
        Task Create(ProductPrice catagory);
        Task<List<ProductPrice>> GetAll();
    }
}
