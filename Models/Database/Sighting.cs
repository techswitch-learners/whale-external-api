using System.Collections.Generic;

namespace WhaleExtApi.Models.Database
{
  public class Sighting
  {
    public int Id { get; set; }
    public string Date { get; set; }
    public int LocationId { get; set; }
    public List<int> SpeciesIds { get; set; }
    public string PhotoUrl { get; set; }
    public string Email { get; set; }
  }
}