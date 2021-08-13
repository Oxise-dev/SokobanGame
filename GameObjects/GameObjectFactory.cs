using Microsoft.Xna.Framework;
using SocobanGame.Colision;
using SocobanGame.FSM;
using SocobanGame.General;
using SocobanGame.Sound;

namespace SocobanGame.GameObjects
{
	public class GameObjectFactory
	{
		public GameObject CreateGameObject(int id, Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager, Level level, SoundManager soundManager)
		{
			if (id == GameObjectID.Floor)
			{
				return new Floor(position, game, spriteSheet, colisionManager);
			}
			else if (id == GameObjectID.Wall)
			{
				return new Wall(position, game, spriteSheet, colisionManager);
			}
			else if (id == GameObjectID.Player)
			{
				return new Player(position, game, spriteSheet, colisionManager, soundManager, level);
			}
			else if (id == GameObjectID.Goal)
			{
				return new Goal(position, game, spriteSheet, colisionManager, level);
			}
			else if (id == GameObjectID.Box)
			{
				return new Box(position, game, spriteSheet, colisionManager, level);
			}
			return null;
		}

	}
}
