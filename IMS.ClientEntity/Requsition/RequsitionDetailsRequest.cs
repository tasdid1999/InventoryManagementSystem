using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.Requsition
{
   
    public class RequsitionDetailsRequest
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }
    }
}
