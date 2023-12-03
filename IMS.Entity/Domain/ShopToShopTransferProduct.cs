using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{

    [Table("ShopToShopTransferProduct", Schema = "Shop")]
    public class ShopToShopTransferProduct : BaseEntity
    {
        public int ShopToShopTransferId { get; set; }

        public ShopToShopTransfer ShopToShopTransfer { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required]
        public decimal Quantity { get; set; }
    }
}
