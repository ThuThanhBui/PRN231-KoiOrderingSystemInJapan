namespace KoiOrderingSystemInJapan.Data.Request.ServiceOrder
{
    public class RequestPaymentServiceModel
    {
        public Guid CustomerServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
