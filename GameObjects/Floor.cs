using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;
using SocobanGame.General;

namespace SocobanGame.GameObjects
{
	public class Floor : GameObject
	{
		public Floor(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager) 
						: base(position, game, spriteSheet, colisionManager)
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
