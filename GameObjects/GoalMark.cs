using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;
using SocobanGame.General;
using System;
using System.Collections.Generic;

namespace SocobanGame.GameObjects
{
	class GoalMark : GameObject
	{
		private readonly SpriteSheet _spriteSheet;
		List<IColideable> colisions = new List<IColideable>();
		public bool IsOccupied = false;
		public GoalMark(Vector2 position, Game game) : base(position, game)
		{
			Tag = "goalMark";

			var playerTexture = game.Content.Load<Texture2D>("SocobanGraphics");
			_spriteSheet = new SpriteSheet( playerTexture, 16, 16);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0.5f, 4, Color.White);
		}

		public override void Update(float deltaTime)
		{
			foreach (var colideable in ColisionManager.Colideables)
			{
				if (Rectangle.Intersects(colideable.Rectangle) && colideable != this)
					colisions.Add(colideable);
			}
			if (colisions.Count == 0)
			{
				IsOccupied = false;
			}
			else
			{
				foreach (var colideable in colisions)
				{
					if (colideable.Tag == "box")
						IsOccupied = true;
				}
			}
			colisions.Clear();
		}
	}
}
