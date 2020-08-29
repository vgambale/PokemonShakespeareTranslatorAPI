using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
