using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using System.Collections.Generic;

namespace SocobanGame.GameObjects
{
	public class Box : GameObject
	{
		private Vector2 _velocity;
		public Box(Vector2 position, Game game, SpriteSheet spriteSheet) : base(position, game, spriteSheet)
		{
			ID = GameObjectID.Box;
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0.4f, 5, Color.White);
		}

		public override void Update(float deltaTime)
		{

		}	
	}
}
