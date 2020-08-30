using Newtonsoft.Json;
using PokemonShakespeareTranslatorAPI.Utilities.Entities;
using PokemonShakespeareTranslatorAPI.Utilities.PokemonServices.Entities;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace PokemonShakespeareTranslatorAPI.Utilities.PokemonServices
{
	public static class PokemonServices
	{
		/// <summary>
		/// Method to retreive pokemon id given pokemon name
		/// </summary>
		/// <param name="pokemonName"></param>
		/// <param name="logger"></param>
		/// <returns></returns>
		public static int getPokemonId(string pokemonName,ILog logger = null)
		{
			string url = "http://pokeapi.co/api/v2/pokemon";
			url = url + "/" + pokemonName;
			var restClient = new RestClient(url);
			var request = new RestRequest(Method.GET);
			var response = restClient.Execute(request);
			if(response.StatusCode != System.Net.HttpStatusCode.OK)
			{
				if (logger != null)
				{
					logger.Error(string.Format("Pokemon not found error :{0}", response.StatusCode));
				}
					return int.MaxValue;
			}
			var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
			return obj["id"];
		}
		/// <summary>
		/// Method to retreive pokemon description given pokemon id
		/// </summary>
		/// <param name="pokemonId"></param>
		/// <param name="logger"></param>
		/// <returns></returns>
		public static string getPokemonDescription(int pokemonId, ILog logger = null)
		{
			string url = "https://pokeapi.co/api/v2/pokemon-species/";
			url = url + "/" + pokemonId;
			var restClient = new RestClient(url);
			var request = new RestRequest(Method.GET);
			var response = restClient.Execute(request);
			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				if (response.StatusCode != System.Net.HttpStatusCode.OK)
				{
					if (logger != null)
					{
						logger.Error(string.Format("Pokemon description not found error :{0}", response.StatusCode));
					}
					return null;
				}
			}
			PokemonDescriptionResponse obj = JsonConvert.DeserializeObject<PokemonDescriptionResponse>(response.Content);
			if (obj.flavor_text_entries.Any())
			{
				if (obj.flavor_text_entries.Where(x => x.version.name == "ruby" && x.language.name == "en").Any())
				{
					return obj.flavor_text_entries.Where(x => x.version.name == "ruby" && x.language.name == "en").FirstOrDefault().flavor_text;
				}
				else if (obj.flavor_text_entries.Where(x => x.version.name == "alpha-sapphire" && x.language.name == "en").Any())
				{
					return obj.flavor_text_entries.Where(x => x.version.name == "alpha-sapphire" && x.language.name == "en").FirstOrDefault().flavor_text;
				}
				else if (obj.flavor_text_entries.Where(x => x.version.name == "red" && x.language.name == "en").Any())
				{
					return obj.flavor_text_entries.Where(x => x.version.name == "red" && x.language.name == "en").FirstOrDefault().flavor_text;
				}
				else if (obj.flavor_text_entries.Where(x => x.version.name == "diamond" && x.language.name == "en").Any())
				{
					return obj.flavor_text_entries.Where(x => x.version.name == "diamond" && x.language.name == "en").FirstOrDefault().flavor_text;
				}
				else
				{
					return obj.flavor_text_entries.Where(x => x.version.name == "ultra-sun" && x.language.name == "en").FirstOrDefault().flavor_text;
				}
			}
			else
			{
				return "no description found";
			}
		}
		/// <summary>
		/// Method to retreive all the pokemon from the pokeapi.co
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string,string> getAllPokemon()
		{
			string url = "https://pokeapi.co/api/v2/pokemon?limit=1050&offset=0";
			var restClient = new RestClient(url);
			var request = new RestRequest(Method.GET);
			var response = restClient.Execute(request);
			GetAllPokemonResponse obj = JsonConvert.DeserializeObject<GetAllPokemonResponse>(response.Content);
			Dictionary<string, string> pokeDex = new Dictionary<string, string>();
			foreach (Result x in obj.results)
			{
				int id = int.Parse(x.url.Split('/')[6]);
				pokeDex.Add(x.name,getPokemonDescription(id));
			}
			return pokeDex;
		}
	}
}
