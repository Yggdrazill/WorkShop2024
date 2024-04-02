using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string Typ { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
