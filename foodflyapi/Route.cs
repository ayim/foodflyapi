using System;
using System.Collections.Generic;

namespace foodflyapi;

public partial class Route
{
    public int RouteId { get; set; }

    public int? AirlineId { get; set; }

    public string DepartureAirport { get; set; } = null!;

    public string DestinationAirport { get; set; } = null!;

    public virtual Airline? Airline { get; set; }

    public virtual ICollection<Meal> Meals { get; } = new List<Meal>();
}
