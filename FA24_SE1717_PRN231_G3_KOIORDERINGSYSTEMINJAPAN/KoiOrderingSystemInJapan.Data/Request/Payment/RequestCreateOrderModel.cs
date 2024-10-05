using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Request.Payment
{
    public class RequestCreateOrderModel
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public string OrderType { get; set; }
        public decimal Price { get; set; }
        public DateTime Buy_date { get; set; }
    }
}
