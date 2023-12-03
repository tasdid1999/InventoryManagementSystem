using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Entity.Domain;

namespace IMS.Infrastructure.Repository.requsitionDetails
{
    public interface IRequsitionDetailsRepository
    {
        Task Create(List<RequsitionDetails> requsitionDetails);
    }
}
