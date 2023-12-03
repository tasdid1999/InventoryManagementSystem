using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.ProductRequest
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public Decimal Price { get; set; }

        public int CatagoryId { get; set; }

        public int BrandId { get; set; }
    }
}
