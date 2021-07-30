using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using System;
using System.Collections.Generic;

namespace SocobanGame.GameObjects
{
	public class Goal : GameObject
	{
		public bool IsOccupied = false;
		public Goal(Vector2 position, Game game, SpriteSheet spriteSheet) : base(position, game, spriteSheet)
		{
			ID = GameObjectID.Goal;
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0.5f, 4, Color.White);
		}

		public override void Update(float deltaTime)
		{

		}
	}
}
