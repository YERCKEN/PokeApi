using PokeApi.Shared.Models;
using RestSharp;
using System.Text.Json;

namespace PokeApi.Client.Services
{
    public class PokeApiClientService
    {
        private readonly RestClient _client;

        public PokeApiClientService(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }



        // Consumir el listado de pokémones y devolverlo como lista
        public async Task<List<PokemonListInfo>> GetPokemonListAsync()
        {
            Console.WriteLine("Obteniendo lista de pokémones desde el API en SERVER...");
            var request = new RestRequest("api/pokemon/list", Method.Get);

            // Realizar la petición al servidor
            var response = await _client.ExecuteAsync(request);

            // Verificar si la petición fue exitosa y si la respuesta no es nula
            if (response.IsSuccessful && response.Content != null)
            {
                // Deserializar la respuesta JSON a una lista de objetos PokemonListInfo
                var pokemonList = JsonSerializer.Deserialize<List<PokemonListInfo>>(response.Content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return pokemonList ?? new List<PokemonListInfo>();
            }

            return new List<PokemonListInfo>(); // Retornar lista vacía en caso de error
        }


        // Obtener detalles de un Pokémon por nombre
        public async Task<PokemonCharacteristics?> GetPokemonByNameAsync(string name)
        {
            Console.WriteLine("Obteniendo Caracteristicas del pokemon desde el API en SERVER...");

            var request = new RestRequest($"api/pokemon/{name}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessful && response.Content != null)
            {
                var pokemon = JsonSerializer.Deserialize<PokemonCharacteristics>(response.Content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return pokemon;
            }

            return null;
        }


    }
}
