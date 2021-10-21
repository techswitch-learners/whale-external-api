using System.Collections.Generic;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Models.Internal
{
  public class SpeciesExtended : Species
  {
    public List<Sighting> Sightings { get; set; }
  }
}