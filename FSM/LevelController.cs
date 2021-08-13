using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SocobanGame.Data;
using SocobanGame.GameObjects;
using SocobanGame.Sound;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.FSM
{
	class LevelController
	{
		private Level _currentLevel;
		private Game _game;
		private readonly SoundManager _soundManager;

		private KeyboardState _keyboardState;
		private KeyboardState _lastKeyboardState;


		private int _currentLevelNumber = 0;
		private float _levelTransitionDelay = 2f;
		private float _levelTransitionSpeed = 0.1f;
		public LevelController(Game game, GameObjectFactory gameObjectFactory, SoundManager soundManager)
		{
			_game = game;
			_soundManager = soundManager;
			_currentLevel = new Level(game, gameObjectFactory, _soundManager);
		}
		public void Update(float deltaTime)
		{
			_lastKeyboardState = _keyboardState;
			_keyboardState = Keyboard.GetState();
			foreach (var gameObject in _currentLevel.GameObjects)
			{
				gameObject.Update(deltaTime);
			}
			_currentLevel.Goals.Update();
			if (KeyPressed(Keys.Z))
				_currentLevel.Revert();

			if (KeyPressed(Keys.R))
				LoadLevel(_currentLevelNumber);

			if (_currentLevel.Goals.Completed)
			{
				_currentLevelNumber++;
				_soundManager.PlaySound(_game.Content.Load<SoundEffect>("Sounds\\GoalEntered"), 0.4f);
				LoadLevel(_currentLevelNumber);
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (var gameObject in _currentLevel.GameObjects)
			{
				gameObject.Draw(spriteBatch);
			}
		}
		public void LoadLevel(int number)
		{
			if (number <= LevelsPath.levelPath.Count - 1)
			{
				_currentLevelNumber = number;
				_currentLevel.LoadContent(LevelsPath.levelPath[number]);
			}
		}
		private void Translate()
		{

		}
		private bool KeyPressed(Keys key)
		{
			if (_keyboardState.IsKeyDown(key) && _lastKeyboardState.IsKeyUp(key))
			{
				//_anyKeyPressed = true;
				return true;
			}
			return false;
		}

	}
}
