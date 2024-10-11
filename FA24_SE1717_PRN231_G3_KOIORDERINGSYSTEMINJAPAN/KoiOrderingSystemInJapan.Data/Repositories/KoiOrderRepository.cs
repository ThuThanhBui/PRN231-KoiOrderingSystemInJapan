using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class KoiOrderRepository : GenericRepository<KoiOrder>
    {
        public KoiOrderRepository() { }
        public KoiOrderRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<KoiOrder>> GetAllAsync()
        {
            return await _context.KoiOrders.Include(x => x.Customer).ToListAsync();
        }
        public async Task<KoiOrder> GetByIdAsync(Guid id)
        {
            return await _context.Set<KoiOrder>()
                .Include(x => x.OrderDetails)
                .ThenInclude(z => z.KoiFish)
                .ThenInclude(g => g.Category)
                .Include(y => y.Customer)
                .Include(h => h.Deliveries)
                .FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
