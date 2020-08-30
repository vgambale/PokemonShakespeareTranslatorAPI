using Newtonsoft.Json;

namespace PokemonShakespeareTranslatorAPI.Utilities.Entities
{
	public class ShakespeareTranslationRequest
	{
		[JsonProperty("text")]
		public string text { get; set; }

		public ShakespeareTranslationRequest(string text)
		{
			this.text = text;
		}
	}
}
