using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Helper
{
    public class DbRequsitionDetailsResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Decimal ProductPrice { get; set; }

        public Decimal ProductQuantity { get; set; }
    }
}
