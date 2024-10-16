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
            return await _context.Sales.Include(e => e.BookingRequest).Include(e => e.SaleStaff).ToListAsync();
        }

        public async Task<Sale> GetByIdIncludeAsync(Guid id)
        {
            return await _context.Sales.Where(e => e.Id == id).Include(e => e.BookingRequest)
                                                                .ThenInclude(br => br.Customer)
                                                            .Include(e => e.BookingRequest)
                                                                .ThenInclude(br => br.Travel)
                                                            .Include(e => e.SaleStaff).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateIsDeleted(Sale sale)
        {
            sale.IsDeleted = true;
            var rs = await _context.SaveChangesAsync();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
    }
}
