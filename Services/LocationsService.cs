using System.Collections.Generic;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Repositories;

namespace WhaleExtApi.Services
{
  public interface ILocationsService
  {
    IEnumerable<Location> GetAllLocations();
    Location GetLocationById(int id);
    Location GetClosestLocation(double latitude, double longitude);
  }

  public class LocationsService : ILocationsService
  {
    private readonly ILocationsRepo _locations;

    public LocationsService(ILocationsRepo locations)
    {
      _locations = locations;
    }

    public IEnumerable<Location> GetAllLocations()
    {
      return _locations.GetAllLocations();
    }

    public Location GetLocationById(int id)
    {
      return _locations.GetLocationById(id);
    }

    public Location GetClosestLocation(double latitude, double longitude)
    {
      return _locations.GetClosestLocation(latitude, longitude);
    }
  }
}
