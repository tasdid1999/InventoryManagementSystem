using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.productCatagory
{
    public interface IProductCatagoryRepository
    {
        Task Create(ProductCatagory catagory);
        Task<List<ProductCatagory>> GetAll(int page , int pageSize);

        Task<bool> IsExist(string catagoryName);
    }
}
