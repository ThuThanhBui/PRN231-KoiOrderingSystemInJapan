namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Invoice
{
    public Guid Id { get; set; }

    public decimal? PaymentAmount { get; set; }

    public DateTime? PaymentDate { get; set; }
    public string? InvoiceNumber { get; set; } // Unique identifier for the invoice

    public DateTime? IssueDate { get; set; } // Date when the invoice was issued

    public DateTime? DueDate { get; set; } // Date when payment is due

    public string? Status { get; set; } // Status of the invoice (e.g., "Paid", "Unpaid", "Overdue")

    public decimal? TaxAmount { get; set; } // Tax amount applied to the invoice

    public decimal? DiscountAmount { get; set; } // Discount amount on the invoice

    public string? PaymentMethod { get; set; } // Method of payment (e.g., "Credit Card", "Bank Transfer")

    public string? Notes { get; set; } // Additional notes or comments on the invoice
    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual KoiOrder? KoiOrder { get; set; }

    public virtual ServiceOrder? ServiceOrder { get; set; }
}