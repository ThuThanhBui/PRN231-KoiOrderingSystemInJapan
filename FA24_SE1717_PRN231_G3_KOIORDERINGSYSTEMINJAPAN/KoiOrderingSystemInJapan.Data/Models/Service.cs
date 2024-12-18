﻿namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Service
{
    public Guid Id { get; set; }

    public string? ServiceName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<ServiceXBookingRequest> ServiceXBookingRequest { get; set; } = new List<ServiceXBookingRequest>();
}