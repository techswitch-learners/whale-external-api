using System.Collections.Generic;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Models.Internal
{
  public class LocationExtended : Location
  {
    public List<Sighting> Sightings { get; set; }
  }
}