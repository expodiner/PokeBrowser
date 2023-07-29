using System;
using System.Text.Json.Serialization;


namespace PokeBrowser
{
    #region PokemonSpriteResources

    internal class PokemonSpriteResources
    {
        /// <summary>
        /// PokemonSpriteResources
        /// </summary>
        public PokemonSpriteResources(Uri front, Uri back)
        {
            this.Front = front;

            this.Back = back;
        }


        /// <summary>
        /// 正面イメージURI
        /// </summary>
        [JsonPropertyName("front_default")]
        public Uri Front { get; }


        /// <summary>
        /// 背面イメージURI
        /// </summary>
        [JsonPropertyName("back_default")]
        public Uri Back { get; }

    }

    #endregion


    #region Pokemon

    internal class Pokemon
    {
        /// <summary>
        /// Pokemonを生成します。
        /// </summary>
        [JsonConstructor]
        public Pokemon(int id, string name, int height, int weight, PokemonSpriteResources sprites)
        {
            this.Id = id;

            this.Name = name;

            this.Height = height;

            this.Weight = weight;

            this.Sprites = sprites;
        }


        /// <summary>
        /// PokemonID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; }


        /// <summary>
        /// Pokemon名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; }


        /// <summary>
        /// 身長
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; }


        /// <summary>
        /// 体重
        /// </summary>
        [JsonPropertyName("weight")]
        public int Weight { get; }


        /// <summary>
        /// スプライトイメージ
        /// </summary>
        [JsonPropertyName("sprites")]
        public PokemonSpriteResources Sprites { get; }

    }

    #endregion

}
