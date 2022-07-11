using System.Collections.Generic;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Repositories;

namespace WhaleExtApi.Services
{
  public interface ISightingsService
  {
    IEnumerable<Sighting> GetAllSightings();
    IEnumerable<Sighting> GetAllSightingsByLocationId(int locationId);
    Sighting GetSightingById(int id);
  }

  public class SightingsService : ISightingsService
  {
    private readonly ISightingsRepo _sightings;

    public SightingsService(ISightingsRepo sightings)
    {
      _sightings = sightings;
    }

    public IEnumerable<Sighting> GetAllSightings()
    {
      return _sightings.GetAllSightings();
    }

    public IEnumerable<Sighting> GetAllSightingsByLocationId(int locationId)
    {
      return _sightings.GetAllSightingsByLocationId(locationId);
    }

    public Sighting GetSightingById(int id)
    {
      return _sightings.GetSightingById(id);
    }
  }
}
