using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeApi.Shared.Models
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
