using Microsoft.AspNetCore.Mvc;
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
      return new SightingListResponse(_sightingsService.GetAllSightings());
    }

    [HttpGet("{id}")]
    public ActionResult<SightingResponse> GetSightingById([FromRoute] int id)
    {
      return new SightingResponse(_sightingsService.GetSightingById(id));
    }
  }
}