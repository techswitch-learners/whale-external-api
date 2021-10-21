using System.Collections.Generic;
using WhaleExtApi.Models.Internal;

namespace WhaleExtApi.Models.Response
{
  public class SightingListResponse
  {
    public List<SightingExtended> Sightings { get; set; }
  }
}