using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class DeliveryRepository : GenericRepository<Delivery>
    {
        public DeliveryRepository() { }
        public DeliveryRepository(KoiOrderingSystemInJapanContext context) {
        _context = context;
        }


        public async Task<List<Delivery>> GetAll()
        {
            return await _context.Deliveries.Include(x => x.KoiOrder).Include(y=>y.DeliveryStaff).ToListAsync();
        }
    }
}
