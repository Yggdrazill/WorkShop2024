using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class OrderRad
{
    public int OrderNumber { get; set; }

    public int ArtikelId { get; set; }

    public int? Antal { get; set; }

    public decimal Pris { get; set; }

    public DateTime? DatumSkapad { get; set; }

    public virtual Artikel Artikel { get; set; } = null!;
}
