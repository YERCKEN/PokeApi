using RestSharp;

// importamos los modelos desde el proyecto compartido
using PokeApi.Shared.Models;

namespace PokeApi.Services
{
    public class PokeApiService 
    {
        //cantidad de pokemones a obtener
        private readonly int _pokemonsAmount = 100;

        // cliente HTTP  // Constructor
        private readonly RestClient _client = new("https://pokeapi.co/api/v2/");
        
        
        //METODO para obtener un listado de 100 pokemons  ------------------------------------------------------------------
        public async Task<List<PokemonListInfo>> GetPokemonListAsync()
        {

            try
            {
                // Obtenemos los 100 pokemones y comenzamos desde el #0
                var request = new RestRequest($"pokemon?limit={_pokemonsAmount}&offset=0");
                var response = await _client.ExecuteGetAsync<PokemonList>(request);

                if (!response.IsSuccessful || response.Data == null)
                {
                    Console.WriteLine($"Error al obtener la lista de pokemones: {response.ErrorMessage} | Código: {response.StatusCode}");
                    return new List<PokemonListInfo>();
                }

                return response.Data.Results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al obtener la lista de pokemones: {ex.Message}");
                // Si hay un error, retornamos una lista vacia
                return new List<PokemonListInfo>();
            }
            
         
        }

        
        //METODO PARA OBTENER UN POKEMON POR SU NOMBRE ------------------------------------------------------------------
        public async Task<PokemonCharacteristics> GetPokemonByNameAsync(string name)
        {
            try {

                var request = new RestRequest($"pokemon/{name}");
                //ExecuteGetAsync : Retorna un objeto RestResponse<T> que contiene toda la información de la respuesta
                var response = await _client.ExecuteGetAsync<PokemonCharacteristics>(request);

                //Vemos el error en especifico y el estado si la respuesta no fue exitosa
                if (!response.IsSuccessful || response.Data == null){
                    
                        Console.WriteLine($"\nError al obterner un pokemon por su nombre: {response.ErrorMessage} | Codigo : {response.StatusCode}");
                        //Retornamos un nuevo objeto PokemonCharacteristics vacío
                        return new PokemonCharacteristics();
                }
                return response.Data;
            }
            //Si hay un error en la petición, lo capturamos y mostramos en consola
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new PokemonCharacteristics();
            }
        }



    }
}
