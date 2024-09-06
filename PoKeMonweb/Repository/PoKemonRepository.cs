using PoKeMonweb.Data;
using PoKeMonweb.Interfaces;
using PoKeMonweb.Models;

namespace PoKeMonweb.Repository
{
    public class PoKemonRepository : IPoKemonRepository
    {
        private readonly DataContext _context;

      
        //public bool CreatePokemons(Models.Pokemon pokemon, out string? mess)
        //{
        //    try
        //    {
        //        _context.Pokemons.Add(pokemon);
        //        _context.SaveChanges();
        //        mess = null;
        //        return true;
        //    }
        //    catch(Exception ex) {
        //        mess = ex.Message;
        //        return false;
        //    }
        //}

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemoRatings(int pokeid)
        {
           var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeid);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating)) / review.Count();
        }

        public bool PoKemonExits(int pokeid)
        {
            return _context.Pokemons.Any(p => p.Id == pokeid);
        }

        public PoKemonRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }
    }
}
