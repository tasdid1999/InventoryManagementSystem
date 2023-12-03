using Dapper;
using Ecom.Entity.Domain;
using IMS.ClientEntity.purchase;
using IMS.ClientEntity.Requsition;
using IMS.Entity.Domain;
using IMS.Entity.Helper;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.purchase
{
    internal class PurchaseRepository : IPurchaseRepository
    {
        private readonly Context _context;
        private readonly SqlConnectionFactory _sqlConnectionFactory;
        public PurchaseRepository(Context context, SqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
       
        public async Task Create(Purchase purchase)
        {
           await _context.purchases.AddAsync(purchase);
        }

        public async Task<List<PurchaseResponse>> GetAll(int page, int pageSize)
        {
            using var connection = _sqlConnectionFactory.Create();

            var purchaseResponse = new List<PurchaseResponse>();

            try
            {
                var products = await connection.QueryAsync<PurchaseResponse, PurchaseProductResponse,PurchaseResponse>($"SP_GetAllPurchase @page={page},@pageSize={pageSize}",

                                           (DBpurchase, DBpurchaseProduct) =>
                                           {
                                               var existingPurchase = purchaseResponse.Where(x => x.PurchaseId == DBpurchase.PurchaseId).FirstOrDefault();

                                               if (existingPurchase is null)
                                               {
                                                   var purchase = new PurchaseResponse();
                                                   purchase.PurchaseId = DBpurchase.PurchaseId;
                                                   purchase.RequisitionId = DBpurchase.RequisitionId;
                                                   purchase.PurchasedProducts = new List<PurchaseProductResponse>();
                                                   purchase.PurchasedProducts.Add(new PurchaseProductResponse { ProductId = DBpurchaseProduct.ProductId, ProductName = DBpurchaseProduct.ProductName, ProductBrandName = DBpurchaseProduct.ProductBrandName, PurchasedPrice = DBpurchaseProduct.PurchasedPrice, PurchasedQuantity = DBpurchaseProduct.PurchasedQuantity, PurchaseDate = DBpurchaseProduct.PurchaseDate });
                                                   purchaseResponse.Add(purchase);
                                               }
                                               else
                                               {
                                                   existingPurchase.PurchasedProducts.Add(new PurchaseProductResponse { ProductId = DBpurchaseProduct.ProductId, ProductName = DBpurchaseProduct.ProductName, ProductBrandName = DBpurchaseProduct.ProductBrandName, PurchasedPrice = DBpurchaseProduct.PurchasedPrice, PurchasedQuantity = DBpurchaseProduct.PurchasedQuantity, PurchaseDate = DBpurchaseProduct.PurchaseDate });
                                               }
                                               return null;
                                           }, splitOn: "ProductId"


                                           );


                return purchaseResponse;
            }
            catch(Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
    }
    }

