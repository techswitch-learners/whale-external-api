using System.Collections.Generic;
using System.Linq;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Models.Internal;
using WhaleExtApi.Repositories;

namespace WhaleExtApi.Services
{
  public interface ISpeciesService
  {
    List<SpeciesExtended> GetAllSpecies();
    SpeciesExtended GetSpeciesById(int id);
    SpeciesExtended GetSpeciesByName(string name);
    SpeciesExtended GetSpeciesByLatinName(string latinName);
  }

  public class SpeciesService : ISpeciesService
  {
    private readonly ISightingsRepo _sightings;
    private readonly ISpeciesRepo _species;

    public SpeciesService(ISightingsRepo sightings, ISpeciesRepo species)
    {
      _sightings = sightings;
      _species = species;
    }

    private SpeciesExtended ExtendSpecies(Species species)
    {
      return new SpeciesExtended {
        Id = species.Id,
        Name = species.Name,
        LatinName = species.LatinName,
        PhotoUrl = species.PhotoUrl,
        Description = species.Description,
        EndangeredStatus = species.EndangeredStatus,
        Sightings = _sightings.GetAllSightingsBySpeciesId(species.Id).ToList(),
      };
    }

    public List<SpeciesExtended> GetAllSpecies()
    {
      return _species
        .GetAllSpecies()
        .Select(ExtendSpecies)
        .ToList();
    }

    public SpeciesExtended GetSpeciesById(int id)
    {
      return ExtendSpecies(_species.GetSpeciesById(id));
    }

    public SpeciesExtended GetSpeciesByName(string name)
    {
      return ExtendSpecies(_species.GetSpeciesByName(name));
    }

    public SpeciesExtended GetSpeciesByLatinName(string latinName)
    {
      return ExtendSpecies(_species.GetSpeciesByLatinName(latinName));
    }
  }
}
