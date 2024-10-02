﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class Service
{
    public Guid Id { get; set; }

    public string ServiceName { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string Note { get; set; }

    public virtual ICollection<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
}