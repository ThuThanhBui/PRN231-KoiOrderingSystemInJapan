namespace KoiOrderingSystemInJapan.Data.Request.KoiOrders
{
    public class RequestPaymentKoiOrderModel
    {
        public Guid? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } 

        public DateTime DeliveryDate { get; set; } 

        public string ShippingAddress { get; set; } 

        public string BillingAddress { get; set; } 

        public string PaymentMethod { get; set; } 

        public bool IsGift { get; set; } 

        public string Note { get; set; } 
        public List<OrderItemDetail> OrderDetailList { get; set; }
    }

    public class OrderItemDetail
    {
        public Guid? KoiFishId { get; set; }
        public decimal? Price { get; set; }
    }
}
