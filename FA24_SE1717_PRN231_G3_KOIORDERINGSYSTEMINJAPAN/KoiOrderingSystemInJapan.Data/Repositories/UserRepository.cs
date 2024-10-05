using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }
        public UserRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.Include(e => e.Customers).ToListAsync();
        }
    }
}
