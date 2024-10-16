using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository() { }

        public CategoryRepository(KoiOrderingSystemInJapanContext context) => _context = context;

    }
}
