using System.Linq;
using System.Collections.Generic;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Database;
using Microsoft.EntityFrameworkCore;

namespace WhaleExtApi.Repositories
{
  public interface ISpeciesRepo
  {
    IEnumerable<Species> GetAllSpecies();
    Species GetSpeciesById(int id);
    Species GetSpeciesByName(string name);
    Species GetSpeciesByLatinName(string latinName);
  }

  public class SpeciesRepo : ISpeciesRepo
  {
    private readonly ApiDbContext _context;

    public SpeciesRepo(ApiDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Species> GetAllSpecies()
    {
      return _context
        .Species;
    }

    public Species GetSpeciesById(int id)
    {
      return _context
        .Species
        .Include(s => s.Sightings)
        .Single(s => s.Id == id);
    }

    public Species GetSpeciesByName(string name)
    {
      return _context
        .Species
        .Include(s => s.Sightings)
        .First(s => s.Name.ToLower().Contains(name.ToLower()));
    }

    public Species GetSpeciesByLatinName(string latinName)
    {
      return _context
        .Species
        .Include(s => s.Sightings)
        .First(s => s.LatinName.ToLower().Contains(latinName.ToLower()));
    }
  }
}