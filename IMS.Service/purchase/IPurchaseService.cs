using IMS.ClientEntity.purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Service.purchase
{
    public interface IPurchaseService
    {
        Task<bool> Create(PurchaseRequest request,int requisitionId , string token);

        Task<List<PurchaseResponse>> GetAll(int page, int pageSize);
    }
}
