using Microsoft.Xna.Framework;
using SocobanGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Colision
{
	public class ColisionManager
	{
		private List<GameObject> _gameObjects = new List<GameObject>();
		public ColisionManager()
		{

		}
		public List<GameObject> GetMoveIntersections(GameObject movingGameObject, Vector2 velocity)
		{
			List<GameObject> intersectedObjects = new List<GameObject>();
			Rectangle moveRectangle = new Rectangle(movingGameObject.Rectangle.X + (int)velocity.X, movingGameObject.Rectangle.Y + (int)velocity.Y, 16, 16);

			// iterating trough objects and finding intersecting ones
			foreach (var gameObject in _gameObjects)
			{
				if (moveRectangle.Intersects(gameObject.Rectangle) && gameObject != movingGameObject)
					intersectedObjects.Add(gameObject);		
			}
			return intersectedObjects;
		}
		public void Add(GameObject gameObject)
		{
			if (gameObject != null)
				_gameObjects.Add(gameObject);
		}
		public void Remove(GameObject gameObject)
		{
			if (_gameObjects.Contains(gameObject))
				_gameObjects.Remove(gameObject);
		}
		public void Clear() => _gameObjects.Clear();

	}
}
