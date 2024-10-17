using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class DeliveryDetailRepository : GenericRepository<DeliveryDetail>
    {
        public DeliveryDetailRepository() { }
        public DeliveryDetailRepository(KoiOrderingSystemInJapanContext context) { }


        public async Task<List<DeliveryDetail>> GetAllById(Guid id)
        {
            var deliverydetails = await _context.DeliveryDetails.Where(x=> x.DeliveryId == id).ToListAsync(); 
            return deliverydetails;
        }

        public async Task<int> UpdateTesting(DeliveryDetail delivery) {
            // Check if the entity with the same Id is already tracked in the context
            var existingEntity = _context.DeliveryDetails.Local.FirstOrDefault(e => e.Id == delivery.Id);

            if (existingEntity != null)
            {
                // Detach the already tracked entity to avoid conflict
                _context.Entry(existingEntity).State = EntityState.Detached;
            }

            // Attach and mark the entity as modified
            var tracker = _context.Attach(delivery);
            tracker.State = EntityState.Modified;

            // Save changes to the database
            return await _context.SaveChangesAsync();
        }

    }
}
