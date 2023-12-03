using IMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Entity.Domain
{
    [Table("Requsition", Schema = "Product")]
    public class Requsition : BaseEntity
    {
      
      public int ApprovedBy { get; set; }

      public virtual List<RequsitionDetails> Requsitions { get;}
       
    }
}
