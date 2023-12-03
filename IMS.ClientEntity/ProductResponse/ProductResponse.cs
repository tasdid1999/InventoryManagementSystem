using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.ProductResponse
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Brand { get; set; }


        public string Catagory {  get; set; }

        public Decimal Price { get; set; }
    }
}
