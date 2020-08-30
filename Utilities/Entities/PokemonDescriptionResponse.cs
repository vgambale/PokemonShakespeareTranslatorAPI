using System.Collections.Generic;

namespace PokemonShakespeareTranslatorAPI.Utilities.PokemonServices.Entities
{
	public class PokemonDescriptionResponse
	{
		public List<FlavorTextEntry> flavor_text_entries { get; set; }
	}
    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class FlavorTextEntry
    {
        public string flavor_text { get; set; }
        public Language language { get; set; }
        public Version version { get; set; }
    }
}
