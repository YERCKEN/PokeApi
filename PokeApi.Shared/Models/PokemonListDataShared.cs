
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

        public string Sprite { get; set; }

    }

    // CARACTERISTICAS DEL POKEMON ()
    public class PokemonCharacteristics
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // JSONs ANIDADOS -- - -
        public List<AbilityWrapper> Abilities { get; set; } = new List<AbilityWrapper>();
        public List<TypeWrapper> Types { get; set; } = new List<TypeWrapper>();

    }

    /*  Estructura de JSOn
     
        "abilities": [
        {
          "ability": {
            "name": "static",
            "url": "https://pokeapi.co/api/v2/ability/9/"
          },
          "is_hidden": false,
          "slot": 1
        },
        {
          "ability": {
            "name": "lightning-rod",
            "url": "https://pokeapi.co/api/v2/ability/31/"
          },
          "is_hidden": true,
          "slot": 3
        }
  ],*/


    public class AbilityWrapper
    {
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
    }

    /*  Estructura de JSOn

     types": [
        {
          "slot": 1,
          "type": {
            "name": "electric",
            "url": "https://pokeapi.co/api/v2/type/13/"
          }
        }
      ]*/

    public class TypeWrapper
    {
        public PokemonType Type { get; set; }
        public int Slot { get; set; }
    }

    public class PokemonType
    {
        public string Name { get; set; }
    }

}
