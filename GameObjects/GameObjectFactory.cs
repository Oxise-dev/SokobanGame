using Microsoft.Xna.Framework;
using SocobanGame.Colision;
using SocobanGame.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.GameObjects
{
	public static class GameObjectFactory
	{
		public static GameObject CreateGameObject(int id, Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager)
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
				return new Player(position, game, spriteSheet, colisionManager);
			}
			else if (id == GameObjectID.Goal)
			{
				return new Goal(position, game, spriteSheet, colisionManager);
			}
			else if (id == GameObjectID.Box)
			{
				return new Box(position, game, spriteSheet, colisionManager);
			}
			return null;
		}

	}
}
