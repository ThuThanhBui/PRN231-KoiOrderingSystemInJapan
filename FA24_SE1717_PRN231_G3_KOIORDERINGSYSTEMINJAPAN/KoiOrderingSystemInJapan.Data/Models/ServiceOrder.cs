﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class ServiceOrder
{
    public Guid Id { get; set; }

    public Guid? CustomerServiceId { get; set; }

    public Guid? InvoiceId { get; set; }

    public int? Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual CustomerService CustomerService { get; set; }

    public virtual Invoice Invoice { get; set; }
}