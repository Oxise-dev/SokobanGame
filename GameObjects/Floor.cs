using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;
using SocobanGame.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.GameObjects
{
	class Floor : GameObject
	{
		private readonly SpriteSheet _spriteSheet;
		public Floor(Vector2 position, Game game) : base(position, game)
		{
			Tag = "floor";

			var playerTexture = game.Content.Load<Texture2D>("SocobanGraphics");
			_spriteSheet = new SpriteSheet( playerTexture, 16, 16);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 1f, 2, Color.White);
		}

		public override void Update(float deltaTime)
		{

		}
	}
}
