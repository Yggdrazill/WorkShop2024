﻿using System;
using System.Collections.Generic;

namespace Database.Entities;

public partial class Kund
{
    public int Id { get; set; }

    public string Namn { get; set; } = null!;

    public string? Mejl { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
