using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{

    [Table("StoreStock", Schema = "Store")]
    public class StoreStock : BaseEntity
    {
        public int StoreBinId { get; set; }

        public virtual StoreBin Bin { get; set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
