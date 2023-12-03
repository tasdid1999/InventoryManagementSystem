using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{

    [Table("ShopToShopTransfer", Schema = "Shop")]
    public class ShopToShopTransfer : BaseEntity
    {
        public int FromShopId { get; set; }

        public virtual Shop FromShop { get; set; }

        public int ToShopId { get; set; }

        public virtual Shop ToShop { get; set; }

       
        public virtual List<ShopToShopTransferProduct> Products { get; set; }
    }
}
