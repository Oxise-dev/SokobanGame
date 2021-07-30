using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;
using SocobanGame.General;

namespace SocobanGame.GameObjects
{
	public class Wall : GameObject
	{
		public Wall(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager) 
						: base(position, game, spriteSheet, colisionManager)
		{
			ID = GameObjectID.Wall;
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 1f, 1, Color.White);
		}

		public override void Update(float deltaTime)
		{
			
		}
	}
}
