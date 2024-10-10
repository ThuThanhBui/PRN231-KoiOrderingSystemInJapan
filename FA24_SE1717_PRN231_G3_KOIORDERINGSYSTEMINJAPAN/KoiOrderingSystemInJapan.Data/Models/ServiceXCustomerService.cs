namespace KoiOrderingSystemInJapan.Data.Models
{
    public partial class ServiceXCustomerService
    {
        public Guid ServiceId { get; set; }

        public Guid CustomerServiceId { get; set; }

        public virtual Service? Service { get; set; }

        public virtual CustomerService? CustomerService { get; set; }
    }
}
