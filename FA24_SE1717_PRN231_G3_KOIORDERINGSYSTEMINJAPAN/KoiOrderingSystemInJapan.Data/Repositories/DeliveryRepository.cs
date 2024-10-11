using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class DeliveryRepository : GenericRepository<Delivery>
    {
        public DeliveryRepository() { }
        public DeliveryRepository(KoiOrderingSystemInJapanContext context) { }
    }
}
