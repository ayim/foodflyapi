using System;
using System.Collections.Generic;

namespace foodflyapi;

public partial class Review
{
    public int Id { get; set; }

    public int MealId { get; set; }

    public DateTime FlightDate { get; set; }

    public int Taste { get; set; }

    public string Class { get; set; }

    public int Cost { get; set; }

    public int Texture { get; set; }

    public int OverallFeeling { get; set; }

    public int? PortionSize { get; set; }

    public string ServedAt { get; set; } = null!;

    public string? Photos { get; set; }

    public virtual Meal Meal { get; set; } = null!;
}
