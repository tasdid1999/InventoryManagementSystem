using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Entity.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UpdatedBy { get; set;}

        public int UpdatedAt { get; set;}

        public int StatusId { get; set; }
    }
}
