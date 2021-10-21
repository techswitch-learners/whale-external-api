using System.Linq;
using System.Collections.Generic;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Repositories
{
  public interface ISightingsRepo
  {
    List<Sighting> GetAllSightings();
    List<Sighting> GetAllSightingsByLocationId(int locationId);
    List<Sighting> GetAllSightingsBySpeciesId(int speciesId);
    Sighting GetSightingById(int id);
  }

  public class SightingsRepo : ISightingsRepo
  {
    private readonly List<Sighting> _sightings = new List<Sighting> {
      new Sighting {
        Id = 1,
        Date = "2021-10-21",
        LocationId = 1,
        PhotoUrl = "https://imgur.com/lDfOB6Y",
        Email = "Tim.Leach@softwire.com",
        SpeciesIds = new List<int> {2},
      },
    };

    public List<Sighting> GetAllSightings()
    {
      return _sightings;
    }

    public List<Sighting> GetAllSightingsByLocationId(int locationId)
    {
      return _sightings
        .Where(s => s.LocationId == locationId)
        .ToList();
    }

    public List<Sighting> GetAllSightingsBySpeciesId(int speciesId)
    {
      return _sightings
        .Where(s => s.SpeciesIds.Contains(speciesId))
        .ToList();
    }

    public Sighting GetSightingById(int id)
    {
      return _sightings
        .Where(s => s.Id == id)
        .Single();
    }
  }
}