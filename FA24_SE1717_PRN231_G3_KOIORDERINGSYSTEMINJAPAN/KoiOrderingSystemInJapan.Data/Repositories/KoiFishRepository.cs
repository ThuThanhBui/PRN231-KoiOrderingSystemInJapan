using KoiOrderingSystemInJapan.Common.Tools;
using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
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
        
        public async Task<List<KoiFish>> GetAllByCategoryAsync(string category)
        {
            var koiFishes = await _context.KoiFishes.Include(k => k.Category).Include(m => m.Size).ToListAsync(); 
            var koiFishByCategory = koiFishes
                .Where(k => SlugHelper.ConvertToSlugName(k.Category.Name) == category && !k.Category.IsDeleted)
                .ToList();
            return koiFishByCategory;
        }

        public async Task<KoiFish> GetByIdAsync(Guid id)
        {
            var query = _context.KoiFishes.AsQueryable();
            query = query.Include(k => k.Category).Include(m => m.Size).Where(m => m.Id == id);

            return await query.SingleOrDefaultAsync();
        }
    }

}
