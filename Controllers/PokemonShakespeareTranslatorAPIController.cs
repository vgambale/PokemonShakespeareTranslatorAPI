using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonShakespeareTranslatorAPI.Utilities;
using PokemonShakespeareTranslatorAPI.Utilities.ShakespereanTranslationServices;

namespace PokemonShakespeareTranslatorAPI.Controllers
{
	[Route("pokemon/")]
	[ApiController]
	public class PokemonShakespeareTranslatorAPIController : ControllerBase
	{
		private ILog logger;

		[HttpGet("{pokemonName}")]
		public PokemonControllerResponse Get(string pokemonName)		
		
		{
			pokemonName = pokemonName.ToLower();
			PokemonControllerResponse response = new PokemonControllerResponse();
			if (!Caching.AppCache.Any())
			{
				string json = System.IO.File.ReadAllText(@"Pokedex.json");
				Dictionary<string, string> pokeDex = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
				Caching.AppCache = pokeDex;
			}
			if (Caching.AppCache.ContainsKey(pokemonName))
			{
				string pokemonDescription = Caching.AppCache[pokemonName];
				string translatedPokemonDescription = ShakespeareTranslator.GetShakespeareTranslation(pokemonDescription);
				if(translatedPokemonDescription == null)
				{
					response.name = pokemonName;
					response.description = "Pokemon description not found";
				}
				else if(string.Compare(translatedPokemonDescription,"") == 0)
				{
					response.name = pokemonName;
					response.description = "Too many request to the web server please wait or buy full version";
				}
				else
				{
					response.name = pokemonName;
					response.description = translatedPokemonDescription;
				}
			}
			else
			{
				response.name = pokemonName;
				response.description = "Pokemon not found";
			}
			return response;
		}

		public PokemonShakespeareTranslatorAPIController(ILog logger)
		{
			this.logger = logger;
		}
	}
}
