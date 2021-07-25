using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SocobanGame.Colision;
using SocobanGame.General;
using System.Collections.Generic;

namespace SocobanGame.GameObjects
{
	class Box : GameObject
	{
		private readonly SpriteSheet _spriteSheet;
		private Vector2 _velocity;
		public bool ColidedWithAnother = false;
		public Box(Vector2 position, Game game) : base(position, game)
		{
			Tag = "box";
			
			var boxTexture = game.Content.Load<Texture2D>("SocobanGraphics");
			_spriteSheet = new SpriteSheet(boxTexture, 16, 16);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0.4f, 5, Color.White);
		}

		public override void Update(float deltaTime)
		{

		}
		public void ApplyVelocity(Vector2 velocity)
		{
			_velocity = velocity;
			if (_velocity != Vector2.Zero && ColisionManager != null)
			{
				List<IColideable> colisions = new List<IColideable>();

				foreach (var colideable in ColisionManager.Colideables)
				{
					Rectangle boxRay = new Rectangle(Rectangle.X + (int)_velocity.X, Rectangle.Y + (int)_velocity.Y, 16, 16);
					if (boxRay.Intersects(colideable.Rectangle) && colideable != this)
					{
						colisions.Add(colideable);
					}

				}
				if (colisions.Count == 0)
				{
					ColidedWithAnother = false;
					Position += _velocity;
					_velocity = Vector2.Zero;
				}
				else
				{
					foreach (var colideable in colisions)
					{
						if (colideable.Tag == "box")
						{
							ColidedWithAnother = true;
							_velocity = Vector2.Zero;
						}
						else if (colideable.Tag == "goalMark")
						{
							var goalMark = colideable as GoalMark;
							if (goalMark.IsOccupied)
							{
								ColidedWithAnother = true;
								_velocity = Vector2.Zero;
							}
							else
							{
								ColidedWithAnother = false;
								Position += _velocity * 16;
								_velocity = Vector2.Zero;
							}
						}
					}
				}
			}

		}		
	}
}
