﻿using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class DeliveryRepository : GenericRepository<Delivery>
    {
        public DeliveryRepository() { }
        public DeliveryRepository(KoiOrderingSystemInJapanContext context) {
        _context = context;
        }


        public async Task<List<Delivery>> GetAll()
        {
            return await _context.Deliveries.Include(x => x.KoiOrder).Include(y=>y.DeliveryStaff).ToListAsync();
        }

        public async Task<int> UpdateTesting(Delivery delivery)
        {
            // Check if the entity with the same Id is already tracked in the context
            var existingEntity = _context.Deliveries.Local.FirstOrDefault(e => e.Id == delivery.Id);

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
 