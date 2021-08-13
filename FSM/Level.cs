using SocobanGame.GameObjects;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using System.Xml.Linq;
using SocobanGame.Colision;
using SocobanGame.Sound;
using System;

namespace SocobanGame.FSM
{
	public class Level
	{
		private readonly Game _game;

		private GameObjectFactory _gameObjectFactory;
		private SoundManager _soundManager;

		public event Action OnNewTurnAdded;
		public event Action OnRevert;
		public ColisionManager ColisionManager = new ColisionManager();

		public GoalsContainer Goals = new GoalsContainer();
		public List<GameObject> GameObjects = new List<GameObject>();
		public Level(Game game, GameObjectFactory gameObjectFactory, SoundManager soundManager)
		{
			_game = game;
			_gameObjectFactory = gameObjectFactory;
			_soundManager = soundManager;
		}
		public void LoadContent(string path)
		{
			// There will be shitcode untill i realize how to make it better

			Goals.Clear();
			GameObjects.Clear();
			ColisionManager.Clear();

			var textures = _game.Content.Load<Texture2D>("SocobanGraphics");
			var spriteSheet = new SpriteSheet(textures, 16, 16);

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
			// Adding objects according to their position in the array
			for (int y = 0; y < levelHeight; y++)
			{
				for (int x = 0; x < levelWidth; x++)
				{
					Vector2 position = new Vector2(x * 16, y * 16);
					var id = tiles2D[x, y];
					SpawnObject(id, position, spriteSheet);
				}
			}
		}
		public void UnloadContent()
		{
			Goals.Clear();
			GameObjects.Clear();
			ColisionManager.Clear();
		}
		private void SpawnObject(int id, Vector2 position, SpriteSheet spriteSheet)
		{
			var gameObject = _gameObjectFactory.CreateGameObject(id, position, _game, spriteSheet, ColisionManager, this, _soundManager);

			if (gameObject != null)
			{
				GameObjects.Add(gameObject);
				if (id > 2)
				{
					var floor = _gameObjectFactory.CreateGameObject(1, position, _game, spriteSheet, ColisionManager, this, _soundManager);
					GameObjects.Add(floor);
				}
			}

			if (gameObject != null && id > 1)
				ColisionManager.Add(gameObject);
		}

		public void Revert() => OnRevert?.Invoke();
		public void AddTurn() => OnNewTurnAdded?.Invoke();
	}
}
