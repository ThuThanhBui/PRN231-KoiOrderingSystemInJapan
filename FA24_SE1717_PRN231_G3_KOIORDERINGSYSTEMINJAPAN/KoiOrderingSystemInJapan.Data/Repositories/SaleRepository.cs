using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class SaleRepository : GenericRepository<Sale>
    {
        public SaleRepository() { }
        public SaleRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<Sale>> GetAllAsync()
        {
            return await _context.Sales.Include(e => e.CustomerService).Include(e => e.SaleStaff).ToListAsync();
        }
    }
}
