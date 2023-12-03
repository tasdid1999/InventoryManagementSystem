using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.productBrand
{
    public interface IProductBrandRepository
    {
        Task Create(ProductBrand brand);
        Task<List<ProductBrand>> GetAll(int page , int pageSize);

        Task<bool> IsExist(string BrandName);
    }
}
