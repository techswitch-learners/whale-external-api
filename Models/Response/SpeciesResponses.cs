using System;
using System.Collections.Generic;
using System.Linq;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Models.Response
{
  public class SpeciesResponseSighting
  {
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string PhotoUrl { get; set; }
    public string Email { get; set; }

    public SpeciesResponseSighting(Sighting sighting)
    {
      Id = sighting.Id;
      Date = sighting.Date;
      PhotoUrl = sighting.PhotoUrl;
      Email = sighting.Email;
    }
  }

  public class SpeciesResponse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LatinName { get; set; }
    public string PhotoUrl { get; set; }
    public string Description { get; set; }
    public string EndangeredStatus { get; set; }
    public List<SpeciesResponseSighting> Sightings { get; set; }

    public SpeciesResponse(Species species)
    {
      Id = species.Id;
      Name = species.Name;
      LatinName = species.LatinName;
      PhotoUrl = species.PhotoUrl;
      Description = species.Description;
      EndangeredStatus = species.EndangeredStatus;
      Sightings = species.Sightings
        .Select(s => new SpeciesResponseSighting(s))
        .ToList();
    }
  }

  public class SpeciesListResponseSpecies
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string LatinName { get; set; }
    public string PhotoUrl { get; set; }
    public string Description { get; set; }
    public string EndangeredStatus { get; set; }

    public SpeciesListResponseSpecies(Species species)
    {
      Id = species.Id;
      Name = species.Name;
      LatinName = species.LatinName;
      PhotoUrl = species.PhotoUrl;
      Description = species.Description;
      EndangeredStatus = species.EndangeredStatus;
    }
  }

  public class SpeciesListResponse
  {
    public List<SpeciesListResponseSpecies> Species { get; set; }

    public SpeciesListResponse(IEnumerable<Species> species)
    {
      Species = species
        .Select(s => new SpeciesListResponseSpecies(s))
        .ToList();
    }
  }
}
