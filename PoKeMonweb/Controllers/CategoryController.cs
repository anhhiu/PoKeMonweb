using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PoKeMonweb.DTO;
using PoKeMonweb.Interfaces;
using PoKeMonweb.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PoKeMonweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController :Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]

        public IActionResult GetCategorys()
        {
            var category = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }
       
        [HttpGet("{cateid}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]

        public IActionResult GetCategory(int cateid)
        {
            if(!_categoryRepository.CategoryExits(cateid))
                return NotFound();
            var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategory(cateid));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);

        }
        [HttpGet("pokemon/{cateid}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategory(int cateid)                                                                          
        {
            var pokemons = _mapper.Map<List<PoKemonDTO>>(
                _categoryRepository.GetPokemonByCategory(cateid));
            var rating = _categoryRepository.GetCategory(cateid);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }

    }
}
