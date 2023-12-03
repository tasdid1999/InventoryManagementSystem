using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("ProductStock", Schema = "Store")]
    public class StoreProductStock : BaseEntity
    {
        public int ProductId { get; set; }

        public virtual Product product { get; set; }

        public int BinId { get; set; }

        public virtual StoreBin Bin { get; set; }

        [Required]
        public Decimal Quantity { get; set; }
    }
}
