using Microsoft.AspNetCore.Mvc;
using WhaleExtApi.Models.Internal;
using WhaleExtApi.Models.Response;
using WhaleExtApi.Services;

namespace WhaleExtApi.Controllers
{
  [ApiController]
  [Route("/api/species")]
  public class SpeciesController : ControllerBase
  {
    private readonly ISpeciesService _speciesService;

    public SpeciesController(ISpeciesService speciesService)
    {
      _speciesService = speciesService;
    }

    [HttpGet]
    public ActionResult<SpeciesListResponse> GetAllSpecies()
    {
      return new SpeciesListResponse {
        Species = _speciesService.GetAllSpecies(),
      };
    }

    [HttpGet("{id}")]
    public ActionResult<SpeciesExtended> GetSpeciesById([FromRoute] int id)
    {
      return _speciesService.GetSpeciesById(id);
    }

    [HttpGet("search")]
    public ActionResult<SpeciesExtended> GetSpeciesByName(
      [FromQuery] string name,
      [FromQuery] string latinName
    )
    {
      if (name is not null)
      {
        return _speciesService.GetSpeciesByName(name);
      }

      return _speciesService.GetSpeciesByLatinName(latinName);
    }
  }
}