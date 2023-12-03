using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("Product",Schema ="Product")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<ProductPrice> prices { get; set; }

        public int ProductBrandId { get; set; }

        public virtual ProductBrand ProductBrand { get; set; }


        public int ProductCatagoryId { get; set; }

        public virtual ProductCatagory ProductCatagory { get; set; }

        public virtual List<PurchasedProduct> PurchasedProducts { get; set; }

      



    }
}