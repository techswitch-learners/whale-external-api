using System;
using System.Collections.Generic;
using System.Linq;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Models.Response
{
  public class LocationResponseSightingSpecies
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LatinName { get; set; }
    public string PhotoUrl { get; set; }
    public string Description { get; set; }
    public string EndangeredStatus { get; set; }

    public LocationResponseSightingSpecies(Species species)
    {
      Id = species.Id;
      Name = species.Name;
      LatinName = species.LatinName;
      PhotoUrl = species.PhotoUrl;
      Description = species.Description;
      EndangeredStatus = species.EndangeredStatus;
    }
  }

  public class LocationResponseSighting
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public List<LocationResponseSightingSpecies> Species { get; set; }
    public string PhotoUrl { get; set; }
    public string Email { get; set; }

    public LocationResponseSighting(Sighting sighting)
    {
      Id = sighting.Id;
      Date = sighting.Date;
      Species = sighting.Species
        .Select(s => new LocationResponseSightingSpecies(s))
        .ToList();
      PhotoUrl = sighting.PhotoUrl;
      Email = sighting.Email;
    }
  }

  public class LocationResponse
  {
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<LocationResponseSighting> Sightings { get; set; }

    public LocationResponse(Location location)
    {
      Id = location.Id;
      Latitude = location.Latitude;
      Longitude = location.Longitude;
      Name = location.Name;
      Description = location.Description;
      Sightings = location.Sightings
        .Select(s => new LocationResponseSighting(s))
        .ToList();
    }
  }

  public class LocationListResponse
  {
    public List<LocationResponse> Locations { get; set; }

    public LocationListResponse(IEnumerable<Location> locations)
    {
      Locations = locations
        .Select(l => new LocationResponse(l))
        .ToList();
    }
  }
}
