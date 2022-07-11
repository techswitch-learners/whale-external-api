using System.Collections.Generic;

namespace WhaleExtApi.Models.Database
{
  public class Location
  {
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Sighting> Sightings { get; set; }
  }
}