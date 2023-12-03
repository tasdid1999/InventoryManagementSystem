using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.ProductResponse;
using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.productBrand
{
    public interface IProductBrandService
    {
        Task<bool> Create(ProductBrandRequest brand,string token);
        Task<List<ProductBrandResponse>> GetAllBrand(int page , int pageSize);

        Task<bool> IsExist(string BrandName);
    }
}
