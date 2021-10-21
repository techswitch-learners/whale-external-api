using System.Collections.Generic;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Models.Internal
{
  public class SightingExtended : Sighting
  {
    public Location Location { get; set; }
    public List<Species> Species { get; set; }
  }
}