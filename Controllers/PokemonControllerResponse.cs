using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShakespeareTranslatorAPI.Controllers
{
	public class PokemonControllerResponse
	{
		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("description")]
		public string description { get; set; }

		public PokemonControllerResponse(string name, string description)
		{
			this.name = name;
			this.description = description;

		}
	}
}
