using Microsoft.AspNetCore.Mvc;
using WhaleExtApi.Models.Internal;
using WhaleExtApi.Models.Response;
using WhaleExtApi.Services;

namespace WhaleExtApi.Controllers
{
  [ApiController]
  [Route("/api/sightings")]
  public class SightingsController : ControllerBase
  {
    private readonly ISightingsService _sightingsService;

    public SightingsController(ISightingsService sightingsService)
    {
      _sightingsService = sightingsService;
    }

    [HttpGet]
    public ActionResult<SightingListResponse> GetAllSightings()
    {
      return new SightingListResponse {
        Sightings = _sightingsService.GetAllSightings(),
      };
    }

    [HttpGet("{id}")]
    public ActionResult<SightingExtended> GetSightingById([FromRoute] int id)
    {
      return _sightingsService.GetSightingById(id);
    }
  }
}