using Microsoft.AspNetCore.Mvc;
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
      return new SpeciesListResponse(_speciesService.GetAllSpecies());
    }

    [HttpGet("{id}")]
    public ActionResult<SpeciesResponse> GetSpeciesById([FromRoute] int id)
    {
      return new SpeciesResponse(_speciesService.GetSpeciesById(id));
    }

    [HttpGet("search")]
    public ActionResult<SpeciesResponse> GetSpeciesByName(
      [FromQuery] string name,
      [FromQuery] string latinName
    )
    {
      if (name is not null)
      {
        return new SpeciesResponse(_speciesService.GetSpeciesByName(name));
      }

      return new SpeciesResponse(_speciesService.GetSpeciesByLatinName(latinName));
    }
  }
}