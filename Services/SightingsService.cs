using System.Collections.Generic;
using System.Linq;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Models.Internal;
using WhaleExtApi.Repositories;

namespace WhaleExtApi.Services
{
  public interface ISightingsService
  {
    List<SightingExtended> GetAllSightings();
    List<SightingExtended> GetAllSightingsByLocationId(int locationId);
    SightingExtended GetSightingById(int id);
  }

  public class SightingsService : ISightingsService
  {
    private readonly ILocationsRepo _locations;
    private readonly ISightingsRepo _sightings;
    private readonly ISpeciesRepo _species;

    public SightingsService(ILocationsRepo locations, ISightingsRepo sightings, ISpeciesRepo species)
    {
      _locations = locations;
      _sightings = sightings;
      _species = species;
    }

    private SightingExtended ExtendSighting(Sighting sighting)
    {
      return new SightingExtended {
          Id = sighting.Id,
          Date = sighting.Date,
          PhotoUrl = sighting.PhotoUrl,
          Email = sighting.Email,
          Location = _locations.GetLocationById(sighting.LocationId),
          LocationId = sighting.LocationId,
          Species = sighting.SpeciesIds.Select(id => _species.GetSpeciesById(id)).ToList(),
          SpeciesIds = sighting.SpeciesIds,
      };
    }

    public List<SightingExtended> GetAllSightings()
    {
      return _sightings
        .GetAllSightings()
        .Select(ExtendSighting)
        .ToList();
    }

    public List<SightingExtended> GetAllSightingsByLocationId(int locationId)
    {
      return _sightings
        .GetAllSightingsByLocationId(locationId)
        .Select(ExtendSighting)
        .ToList();
    }

    public SightingExtended GetSightingById(int id)
    {
      return ExtendSighting(_sightings.GetSightingById(id));
    }
  }
}
