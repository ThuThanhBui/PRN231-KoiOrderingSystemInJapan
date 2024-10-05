using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class ServiceOrderRepository : GenericRepository<ServiceOrder>
    {
        public ServiceOrderRepository() { }
        public ServiceOrderRepository(KoiOrderingSystemInJapanContext context) => _context = context;
    }
}
