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

    [Table("PurchaseProduct", Schema = "Shop")]
    public class PurchasedProduct : BaseEntity
    {
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(PurchaseId))]
        public virtual Purchase Purchase { get; set; }

        public int ProductId { get; set; }  

        public virtual Product Product { get; set; }

        [Required]
        public decimal Price { get; set; }


        [Required]
        public decimal Quantity { get; set; }

       
    }
}
