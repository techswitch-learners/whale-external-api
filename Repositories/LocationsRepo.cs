using System.Linq;
using System.Collections.Generic;
using WhaleExtApi.Models.Database;
using System;
using WhaleExtApi.Database;
using Microsoft.EntityFrameworkCore;

namespace WhaleExtApi.Repositories
{
  public interface ILocationsRepo
  {
    IEnumerable<Location> GetAllLocations();
    Location GetLocationById(int id);
    Location GetClosestLocation(double latitude, double longitude);
  }

  public class LocationsRepo : ILocationsRepo
  {
    private readonly ApiDbContext _context;

    public LocationsRepo(ApiDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Location> GetAllLocations()
    {
      return _context
        .Locations
        .Include(l => l.Sightings)
        .ThenInclude(s => s.Species);
    }
    public Location GetLocationById(int id)
    {
      return _context
        .Locations
        .Include(l => l.Sightings)
        .ThenInclude(s => s.Species)
        .Single(s => s.Id == id);
    }
    public Location GetClosestLocation(double latitude, double longitude)
    {
      // GeoCoordinate searchedLocation = new GeoCoordinate(latitude, longitude);

      // return _locations
      //   .OrderBy(l => l.Coordinates.GetDistanceTo(searchedLocation))
      //   .First();
      throw new NotImplementedException();
    }
  }
}