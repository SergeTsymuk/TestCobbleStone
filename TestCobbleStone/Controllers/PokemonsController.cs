using Microsoft.AspNetCore.Mvc;
using TestCobbleStone.Services;

namespace TestCobbleStone.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonsController : ControllerBase
    {
        private PokemonServices _pokemonServices;

        public PokemonsController(PokemonServices pokemonServices)
        {
            _pokemonServices = pokemonServices;
        }

        [HttpGet]
        public IActionResult GetPokemons(int page, string name, int? hp, int? attack, int? defense)
        {
            var result = _pokemonServices.GetPaged(page, 10, name, hp, attack, defense);

            return Ok(result);
        }
    }
}
