using PoKeMonweb.Models;

namespace PoKeMonweb.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryid);
        bool CategoryExits(int id);
    }
}
