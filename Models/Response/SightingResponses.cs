using System;
using System.Collections.Generic;
using System.Linq;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Models.Response
{
  public class SightingResponseLocation
  {
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public SightingResponseLocation(Location location)
    {
      Id = location.Id;
      Latitude = location.Latitude;
      Longitude = location.Longitude;
      Name = location.Name;
      Description = location.Description;
    }
  }

  public class SightingResponseSpecies
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LatinName { get; set; }
    public string PhotoUrl { get; set; }
    public string Description { get; set; }
    public string EndangeredStatus { get; set; }

    public SightingResponseSpecies(Species species)
    {
      Id = species.Id;
      Name = species.Name;
      LatinName = species.LatinName;
      PhotoUrl = species.PhotoUrl;
      Description = species.Description;
      EndangeredStatus = species.EndangeredStatus;
    }
  }

  public class SightingResponse
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public SightingResponseLocation Location { get; set; }
    public List<SightingResponseSpecies> Species { get; set; }
    public string PhotoUrl { get; set; }
    public string Email { get; set; }

    public SightingResponse(Sighting sighting)
    {
      Id = sighting.Id;
      Date = sighting.Date;
      Location = new SightingResponseLocation(sighting.Location);
      Species = sighting.Species
        .Select(s => new SightingResponseSpecies(s))
        .ToList();
      PhotoUrl = sighting.PhotoUrl;
      Email = sighting.Email;
    }
  }

  public class SightingListResponse
  {
    public List<SightingResponse> Sightings { get; set; }

    public SightingListResponse(IEnumerable<Sighting> sightings)
    {
      Sightings = sightings
        .Select(s => new SightingResponse(s))
        .ToList();
    }
  }
}
