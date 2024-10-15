namespace KoiOrderingSystemInJapan.Data.Request.ServiceOrder
{
    public class RequestPaymentServiceModel
    {
        public Guid BookingRequestId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
