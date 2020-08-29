using Newtonsoft.Json;
using PokemonShakespeareTranslatorAPI.Utilities.PokemonServices.Entities;
using RestSharp;
using System.Linq;

namespace PokemonShakespeareTranslatorAPI.Utilities.PokemonServices
{
	public static class Pokemon
	{
		public static int getPokemonId(string pokemonName)
		{
			string url = "http://pokeapi.co/api/v2/pokemon";
			url = url + "/" + pokemonName;
			var restClient = new RestClient(url);
			var request = new RestRequest(Method.GET);
			var response = restClient.Execute(request);
			if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return int.MaxValue;
			}
			var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
			return obj["id"];
		}
		public static string getPokemonDescription(int pokemonId)
		{
			string url = "https://pokeapi.co/api/v2/pokemon-species/";
			url = url + "/" + pokemonId;
			var restClient = new RestClient(url);
			var request = new RestRequest(Method.GET);
			var response = restClient.Execute(request);
			if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				return null;
			}
			PokemonDescriptionResponse obj = JsonConvert.DeserializeObject<PokemonDescriptionResponse>(response.Content);
			return obj.flavor_text_entries.Where(x => x.version.name == "ruby").FirstOrDefault().flavor_text;
		}
	}
}
