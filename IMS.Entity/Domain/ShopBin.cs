using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("ShopBin", Schema = "Shop")]
    public class ShopBin : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int ShopRowId { get; set; }

        public virtual ShopRow ShopRow { get; set; }

        [Required]
        public Decimal Capacity { get; set; }


    }
}
