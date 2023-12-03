using Dapper;
using IMS.ClientEntity.shopToshopTransfer;
using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.shopToShopTransfer
{
    public class ShopToShopTransferRespository : IShopToShopTransferRepository
    {
        private readonly Context _context;
        private readonly SqlConnectionFactory _connectionFactory;
        public ShopToShopTransferRespository(Context context,SqlConnectionFactory connectionFactory)
        {
            _context = context;
            _connectionFactory = connectionFactory;
        }
        public async Task Create(ShopToShopTransfer shopToShopTransfer)
        {
            await _context.shopToShopTransfer.AddAsync(shopToShopTransfer);
        }

        public async Task<List<ShopToShopTransferResponse>> GetAll(int page, int pageSize)
        {
            using var conn = _connectionFactory.Create();

            var res = await conn.QueryAsync<ShopToShopTransferResponse>($"EXEC SP_GetAllShopToShopTransfer @page={page},@pageSize={pageSize}");

            return res.ToList();
        }

        public async Task<ShopToShopTransferDetailsResponse> GetById(int id)
        {
            using var conn = _connectionFactory.Create();
            var response = new ShopToShopTransferDetailsResponse();

            var res = await conn.QueryAsync<ShopToShopTransferDetailsResponse, ShopToShopTransferProductResponse, ShopToShopTransferDetailsResponse>($"EXEC SP_GetShopToShopTransferById @id = {id}", (details, products) =>
            {
                if(response.Products is null)
                {
                    response.Id = details.Id;
                    response.FromShopName = details.FromShopName;
                    response.ToShopName = details.ToShopName;
                    response.Products = new List<ShopToShopTransferProductResponse>();
                    response.Products.Add(new ShopToShopTransferProductResponse { ProductName = products.ProductName, Quantity = products.Quantity });
                }
                else
                {
                    response.Products.Add(new ShopToShopTransferProductResponse { ProductName = products.ProductName, Quantity = products.Quantity });
                }

                return null;
            },splitOn : "ProductId");

            return response;
        }
    }
}
