using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;

namespace SocobanGame.GameObjects
{
	public class Floor : GameObject
	{
		public Floor(Vector2 position, Game game, SpriteSheet spriteSheet) : base(position, game, spriteSheet)
		{
			ID = GameObjectID.Floor;
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
