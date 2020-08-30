using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShakespeareTranslatorAPI.Utilities.Entities
{
	public class Pokemon
	{
		public int id { get; set; }
		public string name { get; set; }
		public string description { get; set; }

		public Pokemon(int id,string name,string description)
		{
			this.id = id;
			this.name = name;
			this.description = description;
		}
	}
}
