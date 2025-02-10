using Microsoft.AspNetCore.Mvc;
using PokeApi.Services;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        // Instanciamos el servicio 
        private readonly PokeApiService _pokeApiService = new PokeApiService();


        // Endpoint para obtener un listado de 100 pokémones
        // Ejemplo de llamada: GET api/pokemon/list
        [HttpGet("list")]
        public async Task<IActionResult> GetPokemonList()
        {
            var pokemons = await _pokeApiService.GetPokemonListAsync();
            return Ok(pokemons);
        }


        // Endpoint para obtener un pokémon por nombre
        // Ejemplo de llamada: GET api/pokemon/{name}
        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokemonByName(string name)
        {
            var pokemon = await _pokeApiService.GetPokemonByNameAsync(name);
            if (pokemon == null)
            {
                // Si no se encuentra el pokémon, se responde con 404 Not Found
                return NotFound(new { Message = $"No se encontró un pokémon con el nombre: {name}" });
            }
            return Ok(pokemon);
        }
    }
}
