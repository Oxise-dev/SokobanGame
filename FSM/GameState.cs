using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SocobanGame.GameObjects;
using SocobanGame.General;
using System;
using System.Collections.Generic;
using System.Xml;

namespace SocobanGame.FSM
{
	class GameState : BaseState
	{
		private static int ScreenSizeMultiplier = 2;

		private string filePath = "D:\\Monogame Learning\\SocobanGame\\LevelData\\level_0.xml";
		private SpriteBatch _spriteBatch;
		private ContentManager _content;
		private RenderTarget2D _screen;

		private GameObjectFactory _gameObjectFactory;
		private Level _currentLevel;

		public GameState(StateMachine stateMachine) : base(stateMachine)
		{
			_content = StateMachine.Game.Content;

			_gameObjectFactory = new GameObjectFactory();
		}
		public override void Enter()
		{
			_screen = new RenderTarget2D(StateMachine.Game.GraphicsDevice, 400, 400);
			_spriteBatch = new SpriteBatch(StateMachine.Game.GraphicsDevice);

			_currentLevel = new Level(StateMachine.Game, _gameObjectFactory);
			_currentLevel.LoadContent(filePath);
		}
		public override void Exit()
		{

		}
		public override void Update(float deltaTime)
		{
			var keyboardState = Keyboard.GetState();
			if (keyboardState.IsKeyDown(Keys.R))
			{
				_currentLevel.LoadContent(filePath);
			}
			foreach (var gameObject in _currentLevel.GameObjects)
			{
				gameObject.Update(deltaTime);
			}
		}
		public override void Draw()
		{
			StateMachine.Game.GraphicsDevice.SetRenderTarget(_screen);
			StateMachine.Game.GraphicsDevice.Clear(Color.MediumPurple);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.BackToFront);
			foreach (var gameObject in _currentLevel.GameObjects)
			{
				gameObject.Draw(_spriteBatch);
			}
			_spriteBatch.End();
			StateMachine.Game.GraphicsDevice.SetRenderTarget(null);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			_spriteBatch.Draw(_screen, new Rectangle(0, 0, 400 * ScreenSizeMultiplier, 400 * ScreenSizeMultiplier), Color.White);
			_spriteBatch.End();		
		}
	}
}
