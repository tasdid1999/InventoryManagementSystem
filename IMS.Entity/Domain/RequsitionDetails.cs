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
    [Table("RequsitionDetails", Schema = "Product")]
    public class RequsitionDetails : BaseEntity
    {
        public int RequsitionId { get; set; }

        [ForeignKey(nameof(RequsitionId))]
        public virtual Requsition Requsition { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Quantity { get; set; }


    }
}
