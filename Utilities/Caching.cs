using System.Collections.Generic;

namespace PokemonShakespeareTranslatorAPI.Utilities
{
	public static class Caching
	{
        private static Dictionary<string,string> cache;

        private static object cacheLock = new object();
        public static Dictionary<string,string> AppCache
        {
            get
            {
                lock (cacheLock)
                {
                    if (cache == null)
                    {
                        cache = new Dictionary<string, string>();
                    }
                    return cache;
                }
            }
			set
			{
                cache = value;
			}
        }
    }
}
