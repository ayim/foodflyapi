using System;
using System.Collections.Generic;

namespace foodflyapi;

public partial class Plane
{
    public int PlaneId { get; set; }

    public string PlaneType { get; set; } = null!;

    public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
}
