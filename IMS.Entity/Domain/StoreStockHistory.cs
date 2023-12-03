using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("StoreStockHistory", Schema = "Store")]
    public class StoreStockHistory : BaseEntity
    {
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
        [Required]
        public int OperationType { get; set; }

        [Required]
        public Decimal PreviousStock {  get; set; }
        [Required]
        public Decimal CurrentStock { get; set; }
        [Required]
        public DateTime OperationDate { get; set; }


    }
}
