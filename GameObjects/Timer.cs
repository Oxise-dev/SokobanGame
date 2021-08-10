using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;
using SocobanGame.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.GameObjects
{
	class Timer : GameObject
	{
		private float _time = 0f;
		private SpriteFont _font;
		public Timer(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager) : base(position, game, spriteSheet, colisionManager)
		{
			_font = game.Content.Load<SpriteFont>("PixelFont");
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(_font, ((int)_time).ToString(), Position, Color.White);
		}

		public override void Update(float deltaTime)
		{

		}
	}
}
