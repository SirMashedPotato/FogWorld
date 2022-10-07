using System;
using Verse;
using RimWorld;

namespace FogWorld
{
	[DefOf]
	public static class WeatherDefOf
	{
		static WeatherDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(WeatherDefOf));
		}

		//vanilla weather, but no defOf in vanilla code
		public static WeatherDef Fog;
	}
}
