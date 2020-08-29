using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
			PokemonControllerResponse response = new PokemonControllerResponse("test", "test");
			response.name = pokemonName;
			int pokemonid = Pokemon.getPokemonId(pokemonName,logger);
			if(pokemonid == int.MaxValue)
			{
				response.description = "Pokemon not found";
				return response;
			}
			string pokemonDescription = Pokemon.getPokemonDescription(pokemonid, logger);
			if (pokemonDescription == null)
			{
				response.description = "Pokemon descriptio not found";
				return response;
			}
			//string resultDescription = ShakespeareTranslator.GetShakespeareTranslation(pokemonDescription);
			return response;
		}

		public PokemonShakespeareTranslatorAPIController(ILog logger)
		{
			this.logger = logger;
		}
	}
}
