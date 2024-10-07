using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class ServiceOrderRepository : GenericRepository<ServiceOrder>
    {
        public ServiceOrderRepository() { }
        public ServiceOrderRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<ServiceOrder>> GetAllAsync()
        {
            return await _context.ServiceOrders.Include(e => e.Invoice).ToListAsync();
        }
    }
}
