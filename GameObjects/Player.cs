using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SocobanGame.Colision;
using SocobanGame.FSM;
using SocobanGame.General;
using SocobanGame.Sound;
using SocobanGame.Turns;
using System;
using System.Collections.Generic;

namespace SocobanGame.GameObjects
{
	public class Player : GameObject
	{
		private SoundManager _soundManager;
		private SoundEffect _moveSound;
		private SoundEffect _cratePushedSound;

		private Level _level;

		private Vector2 _scale = Vector2.One;

		private Input _input;
		private KeyboardState _keyboardState, _lastKeyboardState;

		private TurnsManager _turn;

		private List<GameObject> _colidedObjects = new List<GameObject>();

		public event Action<Vector2> OnPlayerMoved;
		//private bool _anyKeyPressed;
		//private float _timer = 0f;
		//private float _timerSpeed = 10f;

		//private Vector2 _startPosition;
		public Player(Vector2 position, Game game, SpriteSheet spriteSheet, ColisionManager colisionManager, SoundManager soundManager, Level level) 
						: base(position, game, spriteSheet, colisionManager)
		{
			ID = GameObjectID.Player;

			_level = level;
			_level.OnRevert += Revert;

			_moveSound = game.Content.Load<SoundEffect>("Sounds\\PlayerMoved");
			_cratePushedSound = game.Content.Load<SoundEffect>("Sounds\\BoxMoved");
			_soundManager = soundManager;

			_input = new Input();

			_turn = new TurnsManager(this);
			OnPlayerMoved += _turn.Add;
		}
		public float Speed { get; set; } = 16f;
		private Vector2 _velocity;
 
		public override void Draw(SpriteBatch spriteBatch)
		{
			_spriteSheet.Draw(spriteBatch, Position, 0f, 3, Color.White, _scale, Vector2.Zero);
		}

		public override void Update(float deltaTime)
		{
			_lastKeyboardState = _keyboardState;
			_keyboardState = Keyboard.GetState();

			_scale = Vector2.One;

			_velocity = GetDirection();
			_colidedObjects = ColisionManager.GetMoveIntersections(this, _velocity * 16);

			if (_colidedObjects.Count == 0)
			{
				Position += _velocity * 16;
				if (_velocity != Vector2.Zero)
				{
					_scale.Y *= 1.1f;
					_level.AddTurn();
					OnPlayerMoved?.Invoke(Position);
				}
			}
			else if (_colidedObjects.Count == 1)
			{
				foreach (var colidedObject in _colidedObjects)
				{
					if (colidedObject.ID == GameObjectID.Goal)
					{
						Position += _velocity * 16;
						//_level.AddTurn();
						//OnPlayerMoved?.Invoke(Position);
					}
					else if (colidedObject.ID == GameObjectID.Box)
					{
						var box = colidedObject as Box;
						if (box.ApplyVelocity(_velocity))
						{
							Position += _velocity * 16;
							_scale.Y *= 1.1f;
							_level.AddTurn();
							OnPlayerMoved?.Invoke(Position);
							_soundManager.PlaySound(_moveSound, 0.2f);
						}
					}
				}
			}
			else
			{
				foreach (var colidedObject in _colidedObjects)
				{
					//if (colidedObject.ID == GameObjectID.Goal)
					//{
					//	var goal = colidedObject as Goal;
					//	if (goal.IsOccupied == false)
					//	{
					//		_level.AddTurn();
					//		OnPlayerMoved?.Invoke(Position);
					//		Position += _velocity * 16;
					//	}
					//}
					if (colidedObject.ID == GameObjectID.Box)
					{
						var box = colidedObject as Box;
						if (box.ApplyVelocity(_velocity))
						{
							Position += _velocity * 16;
							_level.AddTurn();
							OnPlayerMoved?.Invoke(Position);
							_soundManager.PlaySound(_moveSound, 0.2f);
						}
					}
				}
			}
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

		public void Revert() => _turn.Revert();

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
