using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.shopBin
{
    public class ShopBinRequest
    {
        public string Name { get; set; }

        public int ShopRowId { get; set; }

        public decimal Capacity { get; set; }
    }
}
