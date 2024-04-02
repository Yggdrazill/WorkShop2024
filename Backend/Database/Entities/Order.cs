using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Order
{
    public int OrderNumber { get; set; }

    public int? KundId { get; set; }

    public int? StatusId { get; set; }

    public decimal Pris { get; set; }

    public DateTime? DatumSkapad { get; set; }

    public virtual Kund? Kund { get; set; }

    public virtual Status? Status { get; set; }
}
