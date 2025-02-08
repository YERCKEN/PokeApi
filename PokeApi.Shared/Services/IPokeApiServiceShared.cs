
// Importamos modelos 
using PokeApi.Shared.Models;

namespace PokeApi.Shared.Services
{

    public interface IPokeApiServiceShared
    {
        // Metodo para obtener un listado de 100 pokemons
        Task<List<PokemonListInfo>> GetPokemonListAsync();
    }
}
