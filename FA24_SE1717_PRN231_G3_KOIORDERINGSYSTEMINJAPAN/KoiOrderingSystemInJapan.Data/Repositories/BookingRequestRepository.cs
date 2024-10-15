using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class BookingRequestRepository : GenericRepository<BookingRequest>
    {
        public BookingRequestRepository() { }

        public BookingRequestRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<BookingRequest>> GetAllAsync()
        {
            return await _context.Set<BookingRequest>()
                .Where(m => !m.IsDeleted)
                .Include(m => m.Customer)
                .Include(m => m.Travel)
                .ToListAsync();
        }

        public async Task<BookingRequest> GetByIdAsync(Guid id)
        {
            return await _context.Set<BookingRequest>()
                .Where(m => !m.IsDeleted)
                .Include(m => m.Customer) 
                .Include(m => m.Travel)  
                .FirstOrDefaultAsync(b => b.Id == id); 
        }
    }
}
