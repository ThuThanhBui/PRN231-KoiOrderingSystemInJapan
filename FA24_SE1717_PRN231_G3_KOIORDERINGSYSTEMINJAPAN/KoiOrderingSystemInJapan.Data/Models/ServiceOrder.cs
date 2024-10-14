﻿namespace KoiOrderingSystemInJapan.Data.Models;

public partial class ServiceOrder
{
    public Guid Id { get; set; }

    public Guid? BookingRequestId { get; set; }

    public Guid? InvoiceId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual BookingRequest? BookingRequest { get; set; }

    public virtual Invoice? Invoice { get; set; }
}