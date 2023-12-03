using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("ShopRow", Schema = "Shop")]
    public class ShopRow : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int ShopRackId { get; set; } 

        public virtual ShopRack ShopRack { get; set; }

        [Required]
        public int NumberOfBin {  get; set; }
    }
}
