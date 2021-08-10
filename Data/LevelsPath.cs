using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Data
{
	public static class LevelsPath
	{
		public static readonly Dictionary<int, string> levelPath = new Dictionary<int, string>()
		{
			{ 0, "LevelData\\level_0.xml" },
			{ 1, "LevelData\\level_1.xml" },
			{ 2, "LevelData\\level_2.xml" },
		};

	}
}
