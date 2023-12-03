using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{

    [Table("StoreRack", Schema = "Store")]
    public class StoreRack : BaseEntity
    {
        public string Name { get; set; }

        public int RoomId { get; set; }

        public virtual StoreRoom Room { get; set; }

        [Required]
        public int NumberOfRow {  get; set; }

        public virtual List<StoreRow> Rows { get; set; }
    }
}
