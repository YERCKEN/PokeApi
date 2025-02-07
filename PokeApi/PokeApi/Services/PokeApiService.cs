    using RestSharp;
    using PokeApi.Models;

    namespace PokeApi.Services
        {
            public class PokeApiService
            {

                    // cliente HTTP 
                    private readonly RestClient _client;

                    // Constructor
                    public PokeApiService() { 

                        _client = new RestClient("https://pokeapi.co/api/v2/");
                    }

                    //METODO para obtener un listado de 100 pokemons
                    public async Task<List<PokemonListInfo>> GetPokemonListAsync(){   

                            // Obtenemos los 100 pokemones y comenzamos desde el #0
                            var request = new RestRequest("pokemon?limit=100&offset=0", Method.Get);
                            var response = await _client.GetAsync<PokemonList>(request);
                        
                            return response?.Results ?? new List<PokemonListInfo>();
                    }
            }
    }
