using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using SocobanGame.Colision;
using System.Collections.Generic;
using SocobanGame.FSM;

namespace SocobanGame.GameObjects
{
	public class Goal : GameObject
	{
		private Level _level;
		private List<GameObject> _gameObjects = new List<GameObject>();

		public bool IsOccupied = false;
		public Goal(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager, Level level) 
						: base(position, game, spriteSheet, colisionManager)
		{
			ID = GameObjectID.Goal;
			_level = level;
			level.Goals.Add(this);
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
