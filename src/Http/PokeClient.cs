using System;
using System.Threading.Tasks;
using Antsik;
using Antsik.Utils;

namespace PokeBrowser.Http
{
    internal class PokeClient : RestClient
    {
        private static readonly Uri pokeBaseUri = new Uri("https://pokeapi.co/api/v2/");


        public PokeClient() : base(PokeClient.pokeBaseUri)
        {
            Console.WriteLine("Created");
        }


        #region GetCatalog

        public async Task<PokeResponse<PokeCatalog>> GetCatalogAsync()
        {
            var response = await this.GetAsync(this.BaseURL.Append("pokemon"));

            return new PokeResponse<PokeCatalog>(response);
        }


        public PokeResponse<PokeCatalog> GetCatalog() => AsyncHelper.RunSync(() => this.GetCatalogAsync());


        public async Task<PokeResponse<PokeCatalog>> GetCatalogAsync(Uri url)
        {
            var response = await this.GetAsync(url);

            return new PokeResponse<PokeCatalog>(response);
        }


        public PokeResponse<PokeCatalog> GetCatalog(Uri url) => AsyncHelper.RunSync(() => this.GetCatalogAsync(url));

        #endregion


        #region GetPokemon

        public async Task<PokeResponse<Pokemon>> GetPokemonAsync(Uri url)
        {
            var response = await this.GetAsync(url);

            return new PokeResponse<Pokemon>(response);
        }


        public PokeResponse<Pokemon> GetPokemon(Uri url) => AsyncHelper.RunSync(() => this.GetPokemonAsync(url));


        public async Task<PokeResponse<Pokemon>> GetPokemonAsync(int id)
        {
            var response = await this.GetAsync(this.BaseURL.Append($"pokemon/{id}"));

            return new PokeResponse<Pokemon>(response);
        }


        public PokeResponse<Pokemon> GetPokemon(int id) => AsyncHelper.RunSync(() => this.GetPokemonAsync(id));


        public async Task<PokeResponse<Pokemon>> GetPokemonAsync(string name)
        {
            var response = await this.GetAsync(this.BaseURL.Append($"pokemon/{name}"));

            return new PokeResponse<Pokemon>(response);
        }


        public PokeResponse<Pokemon> GetPokemon(string name) => AsyncHelper.RunSync(() => this.GetPokemonAsync(name));

        #endregion

    }

}
