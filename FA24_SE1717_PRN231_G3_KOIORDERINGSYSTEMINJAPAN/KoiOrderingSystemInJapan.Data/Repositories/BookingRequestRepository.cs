using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class BookingRequestRepository : GenericRepository<BookingRequest>
    {
        public BookingRequestRepository() { }

        public BookingRequestRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<BookingRequest>> GetAllAsync()
        {
            return await _context.Set<BookingRequest>()
                .Include(m => m.Customer)
                .Include(m => m.Travel)
                .ToListAsync();
        }
    }
}
