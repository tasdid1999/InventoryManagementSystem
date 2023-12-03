using Ecom.Entity.Domain;
using IMS.ClientEntity.purchase;
using IMS.ClientEntity.Requsition;
using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.purchase
{
    public interface IPurchaseRepository
    {
        Task Create(Purchase purchase);

        Task<List<PurchaseResponse>> GetAll(int page, int pageSize);
    }
}
