using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    [Table("StoreRow", Schema = "Store")]
    public class StoreRow : BaseEntity
    {
        public string Name { get; set; }

        public int RackId { get; set; }

        public virtual StoreRack Rack { get; set; }

        public int NumberOfBin {  get; set; }

        public virtual List<StoreBin> Bins { get; set; }
    }
}
