using System.Collections.Generic;

namespace WhaleExtApi.Models.Database
{
  public class Species
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LatinName { get; set; }
    public string PhotoUrl { get; set; }
    public string Description { get; set; }
    public string EndangeredStatus { get; set; }
    public List<Sighting> Sightings { get; set; }
  }
}