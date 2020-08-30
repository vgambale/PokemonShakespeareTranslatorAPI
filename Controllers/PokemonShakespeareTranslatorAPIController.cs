using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonShakespeareTranslatorAPI.Utilities;
using PokemonShakespeareTranslatorAPI.Utilities.Entities;
using PokemonShakespeareTranslatorAPI.Utilities.PokemonServices;
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
					response.statuscode = HttpStatusCode.NotFound;
				}
				else if(string.Compare(translatedPokemonDescription,"") == 0)
				{
					response.name = pokemonName;
					response.description = "Too many request to the web server please wait or buy full version";
					response.statuscode = HttpStatusCode.TooManyRequests;
				}
				else
				{
					response.name = pokemonName;
					response.description = translatedPokemonDescription;
					response.statuscode = HttpStatusCode.OK;
				}
			}
			else
			{
				response.name = pokemonName;
				response.description = "Pokemon not found";
				response.statuscode = HttpStatusCode.NotFound;
			}
			return response;
		}

		public PokemonShakespeareTranslatorAPIController(ILog logger)
		{
			this.logger = logger;
		}
	}
}
