using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data.Request.Sale;
using KoiOrderingSystemInJapan.Data.Request.ServiceOrder;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class ServiceOrderRepository : GenericRepository<ServiceOrder>
    {
        public ServiceOrderRepository() { }
        public ServiceOrderRepository(KoiOrderingSystemInJapanContext context) => _context = context;

        public async Task<List<ServiceOrder>> GetAllAsync()
        {
            return await _context.ServiceOrders.Include(e => e.Invoice)
                .Include(e => e.BookingRequest).ThenInclude(br => br.Customer)
                .Include(e => e.BookingRequest).ThenInclude(br => br.Travel).ToListAsync();
        }

        public async Task<(List<ServiceOrder>, int)> GetAllAsync(ServiceOrderRequest query, int page, int pageSize)
        {
            var queryable = _context.Set<ServiceOrder>().AsQueryable();

            if (query.Quantity.HasValue)
            {
                queryable = queryable.Where(m => m.Quantity == query.Quantity);
            }

            if (query.TotalPrice.HasValue)
            {
                queryable = queryable.Where(m => m.TotalPrice == query.TotalPrice);
            }


            if (query.CreatedDate.HasValue)
            {
                queryable = queryable.Where(m => m.CreatedDate == query.CreatedDate);
            }

            if (query.UpdatedDate.HasValue)
            {
                queryable = queryable.Where(m => m.UpdatedDate == query.UpdatedDate);
            }

            var totalItems = await queryable.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            queryable = queryable.Where(m => m.IsDeleted==false)
                .Include(e => e.Invoice)
                .Include(e => e.BookingRequest).ThenInclude(br => br.Customer)
                .Include(e => e.BookingRequest).ThenInclude(br => br.Travel);
            var data = await queryable
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return (data, totalPages);
        }

        public async Task<bool> UpdateIsDeleted(ServiceOrder serviceOrder)
        {
            serviceOrder.IsDeleted = true;
            var rs = await _context.SaveChangesAsync();
            if (rs > 0)
            {
                return true;
            }
            return false;
        }
    }
}
