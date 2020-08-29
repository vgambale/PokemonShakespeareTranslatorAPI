using Newtonsoft.Json;
using RestSharp;

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
			var obj = JsonConvert.DeserializeObject<dynamic>(response.Content);
			return obj["id"];
		}
	}
}
