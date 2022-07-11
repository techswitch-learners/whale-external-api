using System.Collections.Generic;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Repositories;

namespace WhaleExtApi.Services
{
  public interface ISpeciesService
  {
    IEnumerable<Species> GetAllSpecies();
    Species GetSpeciesById(int id);
    Species GetSpeciesByName(string name);
    Species GetSpeciesByLatinName(string latinName);
  }

  public class SpeciesService : ISpeciesService
  {
    private readonly ISpeciesRepo _species;

    public SpeciesService(ISpeciesRepo species)
    {
      _species = species;
    }

    public IEnumerable<Species> GetAllSpecies()
    {
      return _species.GetAllSpecies();
    }

    public Species GetSpeciesById(int id)
    {
      return _species.GetSpeciesById(id);
    }

    public Species GetSpeciesByName(string name)
    {
      return _species.GetSpeciesByName(name);
    }

    public Species GetSpeciesByLatinName(string latinName)
    {
      return _species.GetSpeciesByLatinName(latinName);
    }
  }
}
