using System.Linq;
using System.Collections.Generic;
using WhaleExtApi.Models.Database;

namespace WhaleExtApi.Repositories
{
  public interface ISpeciesRepo
  {
    List<Species> GetAllSpecies();
    Species GetSpeciesById(int id);
    Species GetSpeciesByName(string name);
    Species GetSpeciesByLatinName(string latinName);
  }

  public class SpeciesRepo : ISpeciesRepo
  {
    private readonly List<Species> _species = new List<Species> {
      new Species {
        Id = 1,
        Name = "Orca",
        LatinName = "Orcinus Orca",
        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/3/37/Killerwhales_jumping.jpg",
        Description = "The killer whale or orca (Orcinus orca) is a toothed whale belonging to the oceanic dolphin family, of which it is the largest member. It is recognizable by its black-and-white patterned body. A cosmopolitan species, killer whales can be found in all of the world's oceans in a variety of marine environments, from Arctic and Antarctic regions to tropical seas; they are absent only from the Baltic and Black seas, and some areas of the Arctic Ocean.",
        EndangeredStatus = "Data Deficient",
      },
      new Species {
        Id = 2,
        Name = "Blue whale",
        LatinName = "Balaenoptera musculus",
        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/1/1c/Anim1754_-_Flickr_-_NOAA_Photo_Library.jpg",
        Description = "The blue whale (Balaenoptera musculus) is a marine mammal belonging to the baleen whale parvorder Mysticeti. Reaching a maximum confirmed length of 29.9 metres (98 ft) and weighing up to 199 tonnes (196 long tons; 219 short tons), it is the largest animal known to have ever existed. The blue whale's long and slender body can be various shades of greyish-blue dorsally and somewhat lighter underneath.",
        EndangeredStatus = "Endangered",
      },
      new Species {
        Id = 3,
        Name = "Humpback whale",
        LatinName = "Megaptera novaeangliae",
        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/6/61/Humpback_Whale_underwater_shot.jpg",
        Description = "The humpback whale (Megaptera novaeangliae) is a species of baleen whale. It is one of the larger rorqual species, with adults ranging in length from 12–16 m (39–52 ft) and weighing around 25–30 t (28–33 short tons). The humpback has a distinctive body shape, with long pectoral fins and a knobbly head. It is known for breaching and other distinctive surface behaviors, making it popular with whale watchers. Males produce a complex song lasting 10 to 20 minutes, which they repeat for hours at a time. All the males in a group will produce the same song, which is different each season. Its purpose is not clear, though it may help induce estrus in females.",
        EndangeredStatus = "Least Concern",
      },
    };

    public List<Species> GetAllSpecies()
    {
      return _species;
    }
    public Species GetSpeciesById(int id)
    {
      return _species
        .Where(s => s.Id == id)
        .Single();
    }
    public Species GetSpeciesByName(string name)
    {
      return _species
        .Where(s => s.Name.ToLower().Contains(name.ToLower()))
        .First();
    }
    public Species GetSpeciesByLatinName(string latinName)
    {
      return _species
        .Where(s => s.LatinName.ToLower().Contains(latinName.ToLower()))
        .First();
    }
  }
}