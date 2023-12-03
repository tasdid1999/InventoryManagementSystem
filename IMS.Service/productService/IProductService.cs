using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.ProductResponse;
using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.productService
{
    public interface IProductService
    {
        Task<bool> Create(ProductRequest product);
        Task<List<ProductResponse>> GetAll(int page , int pageSize);
    }
}
