using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Lagersaldo
{
    public int ArtikelId { get; set; }

    public int? Antal { get; set; }

    public virtual Artikel Artikel { get; set; } = null!;
}
