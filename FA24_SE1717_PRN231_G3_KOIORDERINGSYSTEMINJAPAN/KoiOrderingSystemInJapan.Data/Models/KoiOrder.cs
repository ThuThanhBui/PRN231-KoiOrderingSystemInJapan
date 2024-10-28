namespace KoiOrderingSystemInJapan.Data.Models;

public partial class KoiOrder
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? InvoiceId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }
    public DateTime OrderDate { get; set; } // Date when the order was placed

    public DateTime? DeliveryDate { get; set; } // Date when the order is to be delivered

    public string? Status { get; set; } // Status of the order (e.g., "Pending", "Shipped", "Delivered")

    public string? ShippingAddress { get; set; } // Address to ship the order

    public string? BillingAddress { get; set; } // Billing address for the order

    public string? PaymentMethod { get; set; } // Payment method used (e.g., "Credit Card", "PayPal")

    public bool? IsGift { get; set; } // Indicates if the order is a gift

    public string? Notes { get; set; } // Additional notes for the order

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Delivery? Deliveries { get; set; }

    public virtual Invoice? Invoice { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}