using System.Collections.Generic;
using WhaleExtApi.Models.Internal;

namespace WhaleExtApi.Models.Response
{
  public class LocationListResponse
  {
    public List<LocationExtended> Locations { get; set; }
  }
}