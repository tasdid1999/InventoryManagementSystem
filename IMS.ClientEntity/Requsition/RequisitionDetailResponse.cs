﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.ClientEntity.Requsition
{
    public class RequisitionDetailResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductQuantity { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
