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
			int pokemonid = Pokemon.getPokemonId(pokemonName);
			string pokemonDescription = Pokemon.getPokemonDescription(pokemonid);
			//string resultDescription = ShakespeareTranslator.GetShakespeareTranslation(pokemonDescription);
			PokemonControllerResponse test = new PokemonControllerResponse("test", "test");
			return test;
		}

		public PokemonShakespeareTranslatorAPIController(ILog logger)
		{
			this.logger = logger;
		}
	}
}
