using Ecom.Entity.Domain;
using IMS.ClientEntity.Requsition;
using IMS.Entity.Domain;
using IMS.Entity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.requsition
{
    public interface IRequsitionRepository
    {
        Task Create(Requsition requsition);

        Task<List<RequisitionResponse>> GetAll(int page , int pageSize);

        Task<RequisitionResponse> GetById(int id);
    }
}
