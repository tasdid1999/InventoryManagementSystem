using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("StoreRoom", Schema = "Store")]
    public class StoreRoom : BaseEntity
    {
        public string Name { get; set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        [Required]
        public int NumberOfRack {  get; set; }

        public virtual List<StoreRack> Racks { get; set; }
    }
}
