using Ecom.Entity.Domain;
using Ecom.Service.Token;
using IMS.ClientEntity.Requsition;
using IMS.Entity.Domain;
using IMS.Infrastructure.UnitOfWork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.requsition
{
    public class RequsitionService : IRequsitionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequsitionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> Create(RequsitionRequest request,string token)
        {
            
           
            var createdBy = JwtTokenFactory.GetUserIdFromToken(token);

            var requsition = new Requsition { ApprovedBy = 0 , CreatedAt = DateTime.Now,CreatedBy = createdBy,StatusId= 1 };
           
            _unitOfWork.RequsitionRepository.Create(requsition);

            var listOfRequstionDetails = new List<RequsitionDetails>();

            foreach(var item in request.RequsitionDetails)
            {
                var requDetails = new Entity.Domain.RequsitionDetails() { Requsition = requsition , ProductId = item.ProductId, Price = item.Price, Quantity = item.Quantity, CreatedAt = DateTime.Now , CreatedBy = createdBy, StatusId = 1};
                listOfRequstionDetails.Add(requDetails);
            }

            _unitOfWork.RequsitionDetailsRepository.Create(listOfRequstionDetails);

            return _unitOfWork.SaveChangeAsync();

        }

        public async Task<List<RequisitionResponse>> GetAll(int page, int pageSize)
        {
            return await _unitOfWork.RequsitionRepository.GetAll(page,pageSize);
        }

        public async Task<RequisitionResponse> GetById(int id)
        {
           return  await _unitOfWork.RequsitionRepository.GetById(id);
        }
    }
}
