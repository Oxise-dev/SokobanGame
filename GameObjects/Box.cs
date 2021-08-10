using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.General;
using SocobanGame.Colision;
using System.Collections.Generic;
using System;

namespace SocobanGame.GameObjects
{
	public class Box : GameObject
	{
		private Vector2 _velocity;
		private Vector2 _scale = Vector2.One;

		private List<GameObject> _colidedObjects = new List<GameObject>();

		public event Action<Vector2> OnBoxMoved;

		public Box(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager movementController) 
					: base(position, game, spriteSheet, movementController)
		{
			ID = GameObjectID.Box;
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0.4f, 5, Color.White, _scale, Vector2.Zero);
			_scale = Vector2.One;
		}

		public override void Update(float deltaTime)
		{

		}
		public bool ApplyVelocity(Vector2 velocity)
		{	
			_velocity = velocity;
			_colidedObjects = ColisionManager.GetMoveIntersections(this, _velocity * 16);
			if (_colidedObjects.Count < 2)
			{
				foreach (var colidedObject in _colidedObjects)
					if (colidedObject.ID != GameObjectID.Goal)
						return false;

				Position += _velocity * 16;
				_scale.Y *= 1.1f;
				OnBoxMoved?.Invoke(Position);
				return true;
			}

			return false;
		}
	}
}
