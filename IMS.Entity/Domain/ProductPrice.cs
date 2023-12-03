using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("ProductPrice", Schema = "Product")]
    public class ProductPrice : BaseEntity
    {
        [Required]
        public decimal price { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

       
    }
}
