using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>
    {
        public InvoiceRepository() { }

        public InvoiceRepository(KoiTravelShopContext context)  => _context = context;

    }
}
