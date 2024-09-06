using PoKeMonweb.Data;
using PoKeMonweb.Interfaces;
using PoKeMonweb.Models;
using System.Reflection.Metadata.Ecma335;

namespace PoKeMonweb.Repository
{
    public class CategoryRepostory : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepostory(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExits(int id)
        {
           return _context.Categories.Any(c => c.Id == id);
        }   

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryid)
        {
            return _context.PoKemonCategories.Where(e => e.CategoryId == categoryid).Select(e => e.Pokemon).ToList();
        }
    }
}
