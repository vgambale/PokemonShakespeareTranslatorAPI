using Newtonsoft.Json;

namespace PokemonShakespeareTranslatorAPI.Utilities.Entities
{
	public class Success
    {
        [JsonProperty("total")]
        public int total { get; set; }
    }

    public class Contents
    {
        [JsonProperty("translated")]
        public string translated { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("translation")]
        public string translation { get; set; }
    }

    public class ShakespeareTranslatorResponse
    {
        [JsonProperty("success")]
        public Success success { get; set; }
        [JsonProperty("contents")]
        public Contents contents { get; set; }
    }
}
