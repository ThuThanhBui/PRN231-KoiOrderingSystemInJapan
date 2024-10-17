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
    public class KoiFishRepository : GenericRepository<KoiFish>
    {
        public KoiFishRepository() { } 
        public KoiFishRepository(KoiOrderingSystemInJapanContext context) : base(context) { }

        public async Task<List<KoiFish>> GetAllAsync()
        {
            return await _context.Set<KoiFish>()
                .Include(m => m.Category)
                .Include(m => m.Size)
                .ToListAsync();
        }
    }
}
