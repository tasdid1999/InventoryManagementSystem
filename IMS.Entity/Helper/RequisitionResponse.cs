using IMS.Entity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.Requsition
{
    public class RequisitionResponse
    {
        public int RequisitionId { get; set; }

        public List<DbRequsitionDetailsResponse> detailsResponses { get; set; }
    }
}
