using System;
using System.Collections.Generic;

namespace foodflyapi;

public partial class Airline
{
    public int AirlineId { get; set; }

    public string AirlineName { get; set; } = null!;

    public virtual ICollection<Route> Routes { get; } = new List<Route>();
}
