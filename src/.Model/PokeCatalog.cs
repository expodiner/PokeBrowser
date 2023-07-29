using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;


namespace PokeBrowser
{
    #region PokeCatalogItem

    internal class PokeCatalogItem
    {
        /// <summary>
        /// PokeCatalogItem
        /// </summary>
        [JsonConstructor]
        public PokeCatalogItem(string name, Uri url)
        {
            this.Name = name;

            this.Url = url;
        }


        /// <summary>
        /// Pokemon名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }


        /// <summary>
        /// PokemonリソースURL
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; }


        /// <inheritdoc/>
        public override string ToString() => this.Name;

    }

    #endregion


    #region class PokeCatalog

    internal class PokeCatalog
    {
        /// <summary>
        /// PokeCatalogを生成します。
        /// </summary>
        [JsonConstructor]
        public PokeCatalog(int count, Uri next, Uri previous, PokeCatalogItem[] results)
        {
            this.Count = count;

            this.Next = next;

            this.Previous = previous;

            this.Results = results;
        }


        /// <summary>
        /// カタログ総数
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; }


        /// <summary>
        /// カタログ次ページリソースURL
        /// </summary>
        [JsonPropertyName("next")]
        public Uri Next { get; }


        /// <summary>
        /// カタログ前ページリソースURL
        /// </summary>
        [JsonPropertyName("previous")]
        public Uri Previous { get; }


        /// <summary>
        /// カタログアイテム
        /// </summary>
        [JsonPropertyName("results")]
        public PokeCatalogItem[] Results { get; }

    }

    #endregion

}
