using IMS.ClientEntity.Requsition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.requsition
{
    public interface IRequsitionService
    {
        Task<bool> Create(RequsitionRequest request,string token);

        Task<List<RequisitionResponse>> GetAll(int page, int pageSize);

        Task<RequisitionResponse> GetById(int id);

        
    }
}
