using System.Linq;
using System.Collections.Generic;
using WhaleExtApi.Models.Database;
using WhaleExtApi.Database;
using Microsoft.EntityFrameworkCore;

namespace WhaleExtApi.Repositories
{
  public interface ISightingsRepo
  {
    IEnumerable<Sighting> GetAllSightings();
    IEnumerable<Sighting> GetAllSightingsByLocationId(int locationId);
    IEnumerable<Sighting> GetAllSightingsBySpeciesId(int speciesId);
    Sighting GetSightingById(int id);
  }

  public class SightingsRepo : ISightingsRepo
  {
    private readonly ApiDbContext _context;

    public SightingsRepo(ApiDbContext context)
    {
      _context = context;
    }

    public IEnumerable<Sighting> GetAllSightings()
    {
      return _context
        .Sightings
        .Include(s => s.Species)
        .Include(s => s.Location);
    }

    public IEnumerable<Sighting> GetAllSightingsByLocationId(int locationId)
    {
      return _context
        .Sightings
        .Include(s => s.Species)
        .Include(s => s.Location)
        .Where(s => s.Location.Id == locationId);
    }

    public IEnumerable<Sighting> GetAllSightingsBySpeciesId(int speciesId)
    {
      return _context
        .Sightings
        .Include(s => s.Species)
        .Include(s => s.Location)
        .Where(s => s.Species.Any(sp => sp.Id == speciesId));
    }

    public Sighting GetSightingById(int id)
    {
      return _context
        .Sightings
        .Include(s => s.Species)
        .Include(s => s.Location)
        .Single(s => s.Id == id);
    }
  }
}