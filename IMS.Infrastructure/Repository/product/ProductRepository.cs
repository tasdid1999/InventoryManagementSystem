using Dapper;
using IMS.ClientEntity.ProductResponse;
using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.product
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        private readonly SqlConnectionFactory _sqlConnectionFactory;

        public ProductRepository(Context context, SqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;

        }
        public async Task Create(Product product)
        {
           await _context.Product.AddAsync(product);
        }

        public async Task<List<ProductResponse>> GetAll(int page , int pageSize)
        {
            using var connection = _sqlConnectionFactory.Create();

            var productRespnose = new List<ProductResponse>();

            var products = await connection.QueryAsync<DbProductResponse, ProductBrandResponse, ProductCatagoryResponse,ProductPriceResponse, ProductResponse>(
                                                     $"Product.SP_GetAllProduct @page={page}, @pageSize={pageSize}",
                                                     (product, brand, catagory, price) =>
                                                     {
                                                         var responseProduct = new ProductResponse
                                                         {
                                                             Id = product.ProductId,
                                                             Name = product.ProductName,
                                                             Brand = brand.BrandName,
                                                             Catagory = catagory.CatagoryName,
                                                             Price = price.ProductPrice

                                                         };
                                                         productRespnose.Add(responseProduct);

                                                         return responseProduct;
                                                     },
                                                     splitOn: "BrandId,CatagoryId,PriceId"
                                                     );

            return productRespnose;     

        }
    }
}
