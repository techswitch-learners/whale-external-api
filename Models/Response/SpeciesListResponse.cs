using System.Collections.Generic;
using WhaleExtApi.Models.Internal;

namespace WhaleExtApi.Models.Response
{
  public class SpeciesListResponse
  {
    public List<SpeciesExtended> Species { get; set; }
  }
}