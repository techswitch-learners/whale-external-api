using Microsoft.AspNetCore.Mvc;
using WhaleExtApi.Models.Response;
using WhaleExtApi.Services;

namespace WhaleExtApi.Controllers
{
  [ApiController]
  [Route("/api/locations")]
  public class LocationsController : ControllerBase
  {
    private readonly ILocationsService _locationService;

    public LocationsController(ILocationsService locationService)
    {
      _locationService = locationService;
    }

    [HttpGet]
    public ActionResult<LocationListResponse> GetAllLocations()
    {
      return new LocationListResponse(_locationService.GetAllLocations());
    }

    [HttpGet("{id}")]
    public ActionResult<LocationResponse> GetLocationById([FromRoute] int id)
    {
      return new LocationResponse(_locationService.GetLocationById(id));
    }

    [HttpGet("search")]
    public ActionResult<LocationResponse> GetClosestLocation(
      [FromQuery] double latitude,
      [FromQuery] double longitude
    )
    {
      return StatusCode(501, "This functionality is not yet available. Sorry!");
    }
  }
}