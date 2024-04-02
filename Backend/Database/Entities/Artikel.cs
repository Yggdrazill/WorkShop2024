using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Artikel
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public decimal Pris { get; set; }

    public bool Borttagen { get; set; }

    public virtual Lagersaldo? Lagersaldo { get; set; }

    public virtual ICollection<OrderRad> OrderRads { get; set; } = new List<OrderRad>();
}
