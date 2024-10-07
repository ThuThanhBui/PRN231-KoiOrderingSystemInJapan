using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Models;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>
    {
        public OrderDetailRepository() { }
        public OrderDetailRepository(KoiOrderingSystemInJapanContext context)  => _context = context;
    }
}
