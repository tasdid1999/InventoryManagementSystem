using IMS.Entity.Domain;
using IMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repository.requsitionDetails
{
    public class RequsitionDetailsRepository : IRequsitionDetailsRepository
    {
        private readonly Context _context;

        public RequsitionDetailsRepository(Context context)
        {
            _context = context;
        }
        public async Task Create(List<RequsitionDetails> requsitionDetails)
        {
            await _context.requsitionDetails.AddRangeAsync(requsitionDetails);
        }
    }
}
