using Newtonsoft.Json;
using PokemonShakespeareTranslatorAPI.Utilities.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShakespeareTranslatorAPI.Utilities.ShakespereanTranslationServices
{
	public static class ShakespeareTranslator
	{
		public static string GetShakespeareTranslation(string description)
		{
			string url = "https://api.funtranslations.com/translate/shakespeare.json";
			var restClient = new RestClient(url);
			var request = new RestRequest(Method.POST);
			ShakespeareTranslationRequest requests = new ShakespeareTranslationRequest(description);
			request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(requests), ParameterType.RequestBody);
			request.RequestFormat = DataFormat.Json;
			var response = restClient.Execute(request);
			if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
			{
				return "";
			}
			if (response.StatusCode != System.Net.HttpStatusCode.OK)
			{
				return null;
			}
			ShakespeareTranslatorResponse translation = JsonConvert.DeserializeObject<ShakespeareTranslatorResponse>(response.Content);
			return translation.contents.translated;
		}
	}
}
