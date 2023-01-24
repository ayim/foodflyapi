using System;
using System.Collections.Generic;

namespace foodflyapi;

public partial class Meal
{
    public int MealId { get; set; }

    public int RouteId { get; set; }

    public int? PlaneId { get; set; }

    public string MealName { get; set; } = null!;

    public virtual Plane? Plane { get; set; }

    public virtual ICollection<Review> Reviews { get; } = new List<Review>();

    public virtual Route Route { get; set; } = null!;
}
