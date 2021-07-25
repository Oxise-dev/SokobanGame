using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;
using SocobanGame.General;

namespace SocobanGame.GameObjects
{
	class Wall : GameObject
	{
		private readonly SpriteSheet _spriteSheet;
		public Wall(Vector2 position, Game game) : base(position, game)
		{
			Tag = "wall";

			var playerTexture = game.Content.Load<Texture2D>("SocobanGraphics");
			_spriteSheet = new SpriteSheet(playerTexture, 16, 16);
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
