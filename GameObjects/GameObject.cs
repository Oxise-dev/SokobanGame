using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using SocobanGame.Colision;

namespace SocobanGame.GameObjects
{
	public abstract class GameObject
	{
		protected Game _game;
		protected readonly SpriteSheet _spriteSheet;
		public GameObject(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager)
		{
			Position = position;
			_game = game;
			_spriteSheet = spriteSheet;
			ColisionManager = colisionManager;
		}
		public Vector2 Position { get; set; }
		public int ID { get; set; }
		public ColisionManager ColisionManager{ get; set; }
		public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
		public abstract void Draw(SpriteBatch spriteBatch);
		public abstract void Update(float deltaTime);
	}
}
