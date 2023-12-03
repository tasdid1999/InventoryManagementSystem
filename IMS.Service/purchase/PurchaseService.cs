using Ecom.Service.Token;
using IMS.ClientEntity.purchase;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.purchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PurchaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Create(PurchaseRequest request,int requisitionId, string token)
        {
            try
            {
                var createdBy = JwtTokenFactory.GetUserIdFromToken(token);

                var requisition = await _unitOfWork.RequsitionRepository.GetById(requisitionId);

                foreach (var product in request.PurchasedProducts)
                {
                    var req = requisition.detailsResponses.Where(x => x.ProductId == product.ProductId).FirstOrDefault();

                    if (product.Price > req.ProductPrice || product.Quantity > req.ProductQuantity)
                    {
                        return false;
                    }
                }

                //insert it
                var purchase = new Purchase { PurchaseDate = DateTime.Now, CreatedAt = DateTime.Now, CreatedBy = createdBy, StatusId = 1,ShopId = request.ShopId };
                await _unitOfWork.PurchaseRepository.Create(purchase);

                var listOfProduct = new List<PurchasedProduct>();

                foreach (var item in request.PurchasedProducts)
                {
                    listOfProduct.Add(new PurchasedProduct { Purchase = purchase, ProductId = item.ProductId,Price = item.Price, Quantity = item.Quantity, StatusId = 1, CreatedAt = DateTime.Now, CreatedBy = createdBy });
                }

                await _unitOfWork.PurchasedProductRepository.Create(listOfProduct);

                return await _unitOfWork.SaveChangeAsync();

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public Task<List<PurchaseResponse>> GetAll(int page, int pageSize)
        {
            return _unitOfWork.PurchaseRepository.GetAll(page, pageSize);
        }
    }
}
