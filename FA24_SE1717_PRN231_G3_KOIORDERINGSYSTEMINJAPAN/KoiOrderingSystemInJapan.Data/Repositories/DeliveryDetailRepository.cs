using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.Context;
using KoiOrderingSystemInJapan.Data.Models;

namespace KoiOrderingSystemInJapan.Data.Repositories
{
    public class DeliveryDetailRepository : GenericRepository<DeliveryDetail>
    {
        public DeliveryDetailRepository() { }
        public DeliveryDetailRepository(KoiOrderingSystemInJapanContext context) { }
    }
}
