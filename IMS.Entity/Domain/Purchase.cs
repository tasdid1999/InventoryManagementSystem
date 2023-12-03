using Ecom.Entity.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("Purchase", Schema = "Shop")]
    public class Purchase : BaseEntity
    {
       
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        public virtual List<PurchasedProduct> PurchasedProducts { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }
        
    }
}
