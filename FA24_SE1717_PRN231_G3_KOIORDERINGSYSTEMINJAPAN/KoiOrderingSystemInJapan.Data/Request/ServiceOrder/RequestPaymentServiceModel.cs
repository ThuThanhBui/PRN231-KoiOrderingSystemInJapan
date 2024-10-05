using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Request.ServiceOrder
{
    public class RequestPaymentServiceModel
    {
        public Guid CustomerServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
