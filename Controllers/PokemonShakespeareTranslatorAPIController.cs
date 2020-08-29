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
		[HttpGet("{pokemonName}")]
		public string Get(string pokemonName)
		{
			return pokemonName;
		}
	}
}
