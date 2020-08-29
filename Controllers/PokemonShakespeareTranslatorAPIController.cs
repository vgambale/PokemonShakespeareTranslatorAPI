using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PokemonShakespeareTranslatorAPI.Controllers
{
	[Route("pokemon/")]
	[ApiController]
	public class PokemonShakespeareTranslatorAPIController : ControllerBase
	{
		private ILog logger;
		[HttpGet("{pokemonName}")]
		public string Get(string pokemonName)
		{
			return pokemonName;
		}

		public PokemonShakespeareTranslatorAPIController(ILog logger)
		{
			this.logger = logger;
		}
	}
}
