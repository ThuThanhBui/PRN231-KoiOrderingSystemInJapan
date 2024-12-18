﻿namespace KoiOrderingSystemInJapan.Data.Models;

public partial class DeliveryDetail
{
    public Guid Id { get; set; }

    public Guid? DeliveryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string? Note { get; set; }


    public virtual Delivery? Delivery { get; set; }
}