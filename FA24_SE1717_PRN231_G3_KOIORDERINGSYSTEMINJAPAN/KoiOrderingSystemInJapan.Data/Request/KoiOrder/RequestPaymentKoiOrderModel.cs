﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Request.KoiOrder
{
    public class RequestPaymentKoiOrderModel
    {
        public Guid? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public List<OrderItemDetail> OrderDetailList { get; set; }
    }
    
    public class OrderItemDetail
    {
        public Guid? KoiFishId { get; set; }
        public decimal? Price { get; set; }
    }
}
