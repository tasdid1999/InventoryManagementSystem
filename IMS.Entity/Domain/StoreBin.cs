using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("StoreBin", Schema = "Store")]
    public class StoreBin : BaseEntity
    {
        public string Name { get; set; }

        public int RowId { get; set; }

        public virtual StoreRow Row { get; set; }

        [Required]
        public Decimal ProductQuantity { get; set; }

        public virtual List<StoreProductStock> Stocks { get; set; }
    }
}
