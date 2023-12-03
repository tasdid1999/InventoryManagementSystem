using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("ShopRack", Schema = "Shop")]
    public class ShopRack : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        [Required]
        public int NumberOfRow { get; set; }

        public virtual List<ShopRow> ShopRows { get; set; }
    }
}
