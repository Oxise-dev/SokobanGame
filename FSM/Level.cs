using SocobanGame.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using System.Xml.Linq;
using SocobanGame.Colision;

namespace SocobanGame.FSM
{
	class Level
	{
		private readonly Game _game;
		private readonly SpriteBatch _spriteBatch;

		public List<GameObject> GameObjects = new List<GameObject>();
		public ColisionManager ColisionManager = new ColisionManager();

		public Level(Game game)
		{
			_game = game;
			_spriteBatch = new SpriteBatch(game.GraphicsDevice);
		}
		public void LoadContent(string path)
		{
			// There will be shitcode untill i realize how to make it better

			GameObjects.Clear();
			ColisionManager.Clear();

			var document = XDocument.Load(path);
			int levelWidth = document.Elements()
						.Select(x => int.Parse(x.Element("width").Value)).Sum();
			int levelHeight = document.Elements()
						.Select(x => int.Parse(x.Element("height").Value)).Sum();
			var tiles1D = document.Descendants("data").Select(a => (int)a).ToArray();
			int[,] tiles2D = new int[levelWidth, levelHeight];

			// 1D array cast to a 2D array
			for (int y = 0; y < levelHeight; y++)
			{
				for (int x = 0; x < levelWidth; x++)
				{
					tiles2D[x, y] = tiles1D[y * levelWidth + x];
				}
			}
			// Adding objects according to the integers in the array
			for (int y = 0; y < levelHeight; y++)
			{
				for (int x = 0; x < levelWidth; x++)
				{
					if(tiles2D[x, y] == 3)
					{
						var floor = new Floor(new Vector2(x * 16, y * 16), _game);
						GameObjects.Add(floor);

					}
					else if(tiles2D[x, y] == 2)
					{
						var wall = new Wall(new Vector2(x * 16, y * 16), _game);
						GameObjects.Add(wall);
						ColisionManager.Add(wall);
					}
					else if (tiles2D[x, y] == 5)
					{
						var floor = new Floor(new Vector2(x * 16, y * 16), _game);
						var goalMark = new GoalMark(new Vector2(x * 16, y * 16), _game);
						GameObjects.Add(floor);
						GameObjects.Add(goalMark);
						ColisionManager.Add(goalMark);
					}
					else if (tiles2D[x, y] == 4)
					{
						var floor = new Floor(new Vector2(x * 16, y * 16), _game);
						var player = new Player(new Vector2(x * 16, y * 16), _game);
						GameObjects.Add(floor);
						GameObjects.Add(player);
						ColisionManager.Add(player);
					}
					else if (tiles2D[x, y] == 6)
					{
						var floor = new Floor(new Vector2(x * 16, y * 16), _game);
						var box = new Box(new Vector2(x * 16, y * 16), _game);
						GameObjects.Add(floor);
						GameObjects.Add(box);
						ColisionManager.Add(box);
					}
				}
			}
		}
	}
}
