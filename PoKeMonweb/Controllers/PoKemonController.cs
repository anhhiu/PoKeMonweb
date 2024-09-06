using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PoKeMonweb.Data;
using PoKeMonweb.DTO;
using PoKeMonweb.Interfaces;
using PoKeMonweb.Models;
using System.Collections.Generic;

namespace PoKeMonweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoKemonController :Controller
    {
        private readonly IPoKemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PoKemonController(IPoKemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPoKemons()
        {
            var pokemons = _mapper.Map<List<PoKemonDTO>>(_pokemonRepository.GetPokemons());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type =typeof(Pokemon))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemons(int pokeId)
        {
            if (!_pokemonRepository.PoKemonExits(pokeId))
                return NotFound();
            var pokemon = _mapper.Map<PoKemonDTO>(_pokemonRepository.GetPokemon(pokeId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]

        public IActionResult GetPoKemonRating(int pokeId)
        {
            if(!_pokemonRepository.PoKemonExits(pokeId))
                return NotFound();
            var rating = _pokemonRepository.GetPokemoRatings(pokeId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }
    }
}
