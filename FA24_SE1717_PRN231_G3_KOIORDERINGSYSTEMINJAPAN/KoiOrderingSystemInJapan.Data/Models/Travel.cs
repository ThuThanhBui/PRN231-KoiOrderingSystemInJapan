﻿namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Travel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public decimal? Price { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<BookingRequest> BookingRequests { get; set; } = new List<BookingRequest>();

    public virtual ICollection<TravelFarm> TravelFarms { get; set; } = new List<TravelFarm>();
}