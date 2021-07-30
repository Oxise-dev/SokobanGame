using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using SocobanGame.Colision;
using System;
using System.Collections.Generic;

namespace SocobanGame.GameObjects
{
	public class Goal : GameObject
	{
		public bool IsOccupied = false;
		private List<GameObject> _gameObjects = new List<GameObject>();
		public Goal(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager) 
						: base(position, game, spriteSheet, colisionManager)
		{
			ID = GameObjectID.Goal;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0.5f, 4, Color.White);
		}

		public override void Update(float deltaTime)
		{
			_gameObjects = ColisionManager.GetMoveIntersections(this, Vector2.Zero);
			if (_gameObjects.Count > 0)
			{
				foreach (var gameObject in _gameObjects)
				{
					if (gameObject.ID == GameObjectID.Box)
						IsOccupied = true;
				}
			}
			else
			{
				IsOccupied = false;
			}
		}
	}
}
