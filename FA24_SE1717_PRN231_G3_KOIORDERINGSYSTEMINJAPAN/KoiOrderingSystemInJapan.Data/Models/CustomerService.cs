﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiOrderingSystemInJapan.Data.Models;

public partial class CustomerService
{
    public Guid Id { get; set; }

    public Guid? CustomerId { get; set; }

    public Guid? TravelId { get; set; }

    public int? QuantityService { get; set; }

    public int? NumberOfPerson { get; set; }

    public string Status { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public string Note { get; set; }

    public virtual User Customer { get; set; }

    public virtual Travel Travel { get; set; }

    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<ServiceXCustomerService> ServiceXCustomerService { get; set; } = new List<ServiceXCustomerService>();
}