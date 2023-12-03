using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("Store", Schema = "Store")]
    public class Store : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int NumberOfRoom { get; set; }
        public virtual List<StoreRoom> Rooms { get; set; }

        public virtual List<StoreProductStock> Stocks { get; set; }
    }
}
