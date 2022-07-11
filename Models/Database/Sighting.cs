using System;
using System.Collections.Generic;

namespace WhaleExtApi.Models.Database
{
  public class Sighting
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Location Location { get; set; }
    public List<Species> Species { get; set; }
    public string PhotoUrl { get; set; }
    public string Email { get; set; }
  }
}