using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.ProductResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.productCatagory
{
    public interface IProductCatagoryService
    {

        Task<bool> Create(ProductCatagoryRequest catagory,string token);
        Task<List<ProductCatagoryResponse>> GetAll(int page,int pageSize);

        Task<bool> IsExist(string catagoryName);
    }
}
