using System.Linq;
using System.Collections.Generic;
using WhaleExtApi.Models.Database;
using System;

namespace WhaleExtApi.Repositories
{
  public interface ILocationsRepo
  {
    List<Location> GetAllLocations();
    Location GetLocationById(int id);
    Location GetClosestLocation(double latitude, double longitude);
  }

  public class LocationsRepo : ILocationsRepo
  {
    private readonly List<Location> _locations = new List<Location> {
      new Location {
        Id = 1,
        Latitude = 52.205278,
        Longitude = 0.119167,
        Name = "Cambridge",
        Description = "An unlikely spot for seeing whales, the river Cam plays host to a veritable menagerie of cetacea throughout the year.",
      },
      new Location {
        Id = 2,
        Latitude = 27.988056,
        Longitude = 86.925278,
        Name = "Mount Everest",
        Description = "One of the remotest places on the planet is actually visited regularly by a pod of baleen whales - at least according to those few who have made it to the top!",
      },
      new Location {
        Id = 3,
        Latitude = 46.283333,
        Longitude = 86.666667,
        Name = "Eurasian Pole of Inaccessibility (Xinjiang, China)",
        Description = "The EPIA, in China's Xinjiang region, is the point on earth furthest from the ocean, which makes it extra interesting that a family of blue whales (Earth's largest animal) has settled here!",
      },
      new Location {
        Id = 4,
        Latitude = 90, 
        Longitude = 0,
        Name = "The North Pole",
        Description = "Santa recently enlisted the help of nearly 5000 dolphins to help him with the toy packaging. Their flippers are surprisingly dextrous!",
      }
    };

    public List<Location> GetAllLocations()
    {
      return _locations;
    }
    public Location GetLocationById(int id)
    {
      return _locations
        .Where(s => s.Id == id)
        .Single();
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