using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data
{
    public class Enum
    {
        public enum StatusSale
        {
            Pending,
            Approved,
            Rejected
        }

        public enum BookingRequestStatus
        {
            Pending,
            Approved,
            Rejected
        }

        public enum Role
        {
            Manager,
            SaleStaff,
            Deliver,
            Customer,
        }

        public enum Gender
        {
            Male,
            Female,
            Other
        }

    }
}
