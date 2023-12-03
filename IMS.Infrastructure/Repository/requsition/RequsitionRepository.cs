using Dapper;
using Ecom.Entity.Domain;
using IMS.ClientEntity.ProductResponse;
using IMS.ClientEntity.Requsition;
using IMS.Entity.Domain;
using IMS.Entity.Helper;
using IMS.Infrastructure.Data;

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.requsition
{
    public class RequsitionRepository : IRequsitionRepository
    {
        private readonly Context _context;
        private readonly SqlConnectionFactory _sqlConnectionFactory;
        public RequsitionRepository(Context context, SqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task Create(Requsition requsition)
        {
            await _context.requsitions.AddAsync(requsition);
        }

        public async Task<List<RequisitionResponse>> GetAll(int page, int pageSize)
        {
            using var connection = _sqlConnectionFactory.Create();

            var requisitionResponse = new List<RequisitionResponse>();

            var products = await connection.QueryAsync<DbRequisitionResponse, DbRequsitionDetailsResponse, RequisitionResponse>($"SP_GetAllRequistion @page={page} , @pageSize={pageSize}",

                                            (requisition, requsitionDetails) =>
                                            {
                                                var exisitingReq = requisitionResponse.Where(x => x.RequisitionId == requisition.RequsitionId).FirstOrDefault();
                                                if (exisitingReq is null)
                                                {
                                                    var req = new RequisitionResponse();
                                                    req.RequisitionId = requisition.RequsitionId;
                                                    req.detailsResponses = new List<DbRequsitionDetailsResponse>();
                                                    req.detailsResponses.Add(new DbRequsitionDetailsResponse() { ProductId = requsitionDetails.ProductId, ProductName = requsitionDetails.ProductName, ProductQuantity = requsitionDetails.ProductQuantity, ProductPrice = requsitionDetails.ProductPrice });
                                                    requisitionResponse.Add(req);
                                                }
                                                else
                                                {
                                                    exisitingReq.detailsResponses.Add(new DbRequsitionDetailsResponse { ProductId = requsitionDetails.ProductId, ProductName = requsitionDetails.ProductName, ProductQuantity = requsitionDetails.ProductQuantity, ProductPrice = requsitionDetails.ProductPrice });

                                                }

                                                return exisitingReq;
                                            }, splitOn: "ProductId"
                                            ) ;


            return requisitionResponse;
        }

        public async Task<RequisitionResponse> GetById(int id)
        {
            using var connection = _sqlConnectionFactory.Create();

            var requisitionResponse = new RequisitionResponse();

            var products = await connection.QueryAsync<DbRequisitionResponse, DbRequsitionDetailsResponse, RequisitionResponse>($"EXEC SP_GetRequisitionById @requistionId = {id}",

                                            (requisition, requsitionDetails) =>
                                            {
                                                if (requisitionResponse.detailsResponses is null)
                                                {
                                                    requisitionResponse.RequisitionId = requisition.RequsitionId;
                                                    requisitionResponse.detailsResponses = new List<DbRequsitionDetailsResponse>();
                                                    requisitionResponse.detailsResponses.Add(new DbRequsitionDetailsResponse { ProductId = requsitionDetails.ProductId, ProductName = requsitionDetails.ProductName, ProductPrice = requsitionDetails.ProductPrice, ProductQuantity = requsitionDetails.ProductQuantity });
                                                }
                                                else
                                                {
                                                    requisitionResponse.detailsResponses.Add(new DbRequsitionDetailsResponse { ProductId = requsitionDetails.ProductId, ProductName = requsitionDetails.ProductName, ProductPrice = requsitionDetails.ProductPrice, ProductQuantity = requsitionDetails.ProductQuantity });
                                                }

                                                return requisitionResponse;
                                            }, splitOn: "ProductId"
                                            ) ;


            return requisitionResponse;
        }
    }
    }
    

