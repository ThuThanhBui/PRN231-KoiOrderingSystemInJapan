﻿namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Farm
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Owner { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<FarmCategory> FarmCategories { get; set; } = new List<FarmCategory>();

    public virtual ICollection<TravelFarm> TravelFarms { get; set; } = new List<TravelFarm>();
}