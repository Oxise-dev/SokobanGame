using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SocobanGame.FSM;
using SocobanGame.General;
using System;
using System.Collections.Generic;

namespace SocobanGame.GameObjects
{
	public class Player : GameObject
	{
		private Input _input;
		private KeyboardState _keyboardState, _lastKeyboardState;

		//private bool _anyKeyPressed;
		//private float _timer = 0f;
		//private float _timerSpeed = 10f;

		//private Vector2 _startPosition;
		public Player(Vector2 position, Game game, SpriteSheet spriteSheet) : base(position, game, spriteSheet)
		{
			ID = GameObjectID.Player;
			_input = new Input();
		}
		public float Speed { get; set; } = 16f;
		private Vector2 _velocity { get; set; }
 
		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0f, 3, Color.White);
		}

		public override void Update(float deltaTime)
		{
			_lastKeyboardState = _keyboardState;
			_keyboardState = Keyboard.GetState();

			_velocity = GetDirection();
		}

		private Vector2 GetDirection()
		{
			if (KeyPressed(_input.Left))
			{
				return new Vector2(-1, 0);
			}
			else if (KeyPressed(_input.Right))
			{
				return new Vector2(1, 0);
			}
			else if (KeyPressed(_input.Up))
			{
				return new Vector2(0, -1);
			}
			else if (KeyPressed(_input.Down))
			{
				return new Vector2(0, 1);
			}
			return Vector2.Zero;
		}
		private bool KeyPressed(Keys key)
		{
			if(_keyboardState.IsKeyDown(key) && _lastKeyboardState.IsKeyUp(key))
			{
				//_anyKeyPressed = true;
				return true;
			}
			return false;
		}

		//if (_timer == 0f)
		//{
		//	_startPosition = Position;
		//	Velocity = GetDirection();
		//}
		//if (_timer <= 1f && _anyKeyPressed)
		//{
		//	_timer += _timerSpeed * deltaTime;
		//	_timer = MathHelper.Min(_timer, 1f);
		//	Position = Vector2.Lerp(_startPosition, _startPosition + (Velocity * Speed), _timer);
		//}
		//if (_timer >= 1f && _anyKeyPressed)
		//{
		//	_timer = 0f;
		//	_anyKeyPressed = false;
		//}
	}
}
