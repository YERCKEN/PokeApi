namespace PokeApi.Models
{

    // lISTA DE POKEMONS
    public class PokemonList
    {
        public List<PokemonListInfo> Results { get; set; } = new List<PokemonListInfo>();
    }


    // INFO DEL POKEMON POKEMON (nombre y url)
    public class PokemonListInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }

}
