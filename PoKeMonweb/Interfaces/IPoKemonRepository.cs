using PoKeMonweb.Models;

namespace PoKeMonweb.Interfaces
{
    public interface IPoKemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        //bool CreatePokemons(Models.Pokemon pokemon, out string mess);
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemoRatings(int pokeid);
        bool PoKemonExits(int pokeid);
    }
}
