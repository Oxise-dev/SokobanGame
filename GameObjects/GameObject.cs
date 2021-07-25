using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;

namespace SocobanGame.GameObjects
{
	abstract class GameObject : IColideable
	{
		protected Game _game;		
		public GameObject(Vector2 position, Game game)
		{
			Position = position;
			_game = game;
		}
		public Vector2 Position { get; set; }
		public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, 16, 16);
		public ColisionManager ColisionManager { get; set; }
		public string Tag { get; set; }
		public abstract void Draw(SpriteBatch spriteBatch);
		public abstract void Update(float deltaTime);
	}
}
