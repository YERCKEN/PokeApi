using RestSharp;
// importamos los modelos desde el proyecto compartido
using PokeApi.Shared.Models;
// Importamos el servicio compartido para usar la interfaz
using PokeApi.Shared.Services;

namespace PokeApi.Services
{
    public class PokeApiService : IPokeApiServiceShared
    {
        //cantidad de pokemones a obtener
        private int _PokemonsAmount = 100;

        // cliente HTTP 
        private readonly RestClient _client;

        // Constructor
        public PokeApiService()
        {

            _client = new RestClient("https://pokeapi.co/api/v2/");
        }

        //METODO para obtener un listado de 100 pokemons
        public async Task<List<PokemonListInfo>> GetPokemonListAsync()
        {

            // Obtenemos los 100 pokemones y comenzamos desde el #0
            var request = new RestRequest($"pokemon?limit={_PokemonsAmount}&offset=0", Method.Get);
            var response = await _client.GetAsync<PokemonList>(request);

            return response?.Results ?? new List<PokemonListInfo>();
        }

        //MEOTOD PARA OBTENER UN POKEMON POR SU NOMBRE

        public async Task<PokemonCharacteristics> GetPokemonByNameAsync(string name)
        {
            try {

                var request = new RestRequest($"pokemon/{name}", Method.Get);

                //ExecuteGetAsync : Retorna un objeto RestResponse<T> que contiene toda la información de la respuesta
                //lo uso para saber si la respuesta fue exitosa o no
                var response = await _client.ExecuteGetAsync<PokemonCharacteristics>(request);

                //Vemos el error en especifico y el estado si la respuesta no fue exitosa
                if (!response.IsSuccessful || response.Data == null)
                    {
                        Console.WriteLine($"Error: {response.ErrorMessage} | Codigo : {response.StatusCode}");
                        return null;
                    }

                return response.Data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }



    }
}
