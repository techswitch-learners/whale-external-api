using System.Collections.Generic;
using System.Linq;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Models.Internal;
using WhaleExtApi.Repositories;

namespace WhaleExtApi.Services
{
  public interface ILocationsService
  {
    List<LocationExtended> GetAllLocations();
    LocationExtended GetLocationById(int id);
    LocationExtended GetClosestLocation(double latitude, double longitude);
  }

  public class LocationsService : ILocationsService
  {
    private readonly ILocationsRepo _locations;
    private readonly ISightingsRepo _sightings;

    public LocationsService(ILocationsRepo locations, ISightingsRepo sightings)
    {
      _locations = locations;
      _sightings = sightings;
    }

    private LocationExtended ExtendLocation(Location location)
    {
      return new LocationExtended {
          Id = location.Id,
          Latitude = location.Latitude,
          Longitude = location.Longitude,
          Name = location.Name,
          Description = location.Description,
          Sightings = _sightings.GetAllSightingsByLocationId(location.Id),
      };
    }

    public List<LocationExtended> GetAllLocations()
    {
      return _locations
        .GetAllLocations()
        .Select(ExtendLocation)
        .ToList();
    }

    public LocationExtended GetLocationById(int id)
    {
      return ExtendLocation(_locations.GetLocationById(id));
    }

    public LocationExtended GetClosestLocation(double latitude, double longitude)
    {
      return ExtendLocation(_locations.GetClosestLocation(latitude, longitude));
    }
  }
}
