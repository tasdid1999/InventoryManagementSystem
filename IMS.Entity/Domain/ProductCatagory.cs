using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("ProductCatagory", Schema = "Product")]
    public class ProductCatagory : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }

        public virtual List<PurchasedProduct> PurchasedProducts { get; set; }
    }
}
