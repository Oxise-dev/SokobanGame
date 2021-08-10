using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SocobanGame.Data;
using SocobanGame.GameObjects;
using SocobanGame.Sound;
using System.Collections.Generic;

namespace SocobanGame.FSM
{
	class GameState : BaseState
	{
		private static int ScreenSizeMultiplier = 2;

		private LevelController _levelController;

		private int levelNumber = 0;

		private Texture2D _blackLine;
		private Color _backgroundColor = new Color(10, 3, 32);
		private Effect _shader;

		private SpriteBatch _spriteBatch;
		private ContentManager _content;
		private RenderTarget2D _screen;


		private SoundManager _soundManager;
		private SoundManager _musicManager;

		private SoundEffect _gameSoundtrack;

		private GameObjectFactory _gameObjectFactory;

		public GameState(StateMachine stateMachine) : base(stateMachine)
		{
			_content = StateMachine.Game.Content;

			_gameObjectFactory = new GameObjectFactory();
		}
		public override void Enter()
		{
			_screen = new RenderTarget2D(StateMachine.Game.GraphicsDevice, 15 * 16, 15 * 16);
			_spriteBatch = new SpriteBatch(StateMachine.Game.GraphicsDevice);

			_blackLine = StateMachine.Game.Content.Load<Texture2D>("BlackLine");

			_soundManager = new SoundManager();
			_musicManager = new SoundManager(looping: true);

			_gameSoundtrack = StateMachine.Game.Content.Load<SoundEffect>("Sounds\\SocobanMusic");

			_musicManager.PlaySound(_gameSoundtrack, 0.1f);

			_levelController = new LevelController(StateMachine.Game, _gameObjectFactory, _soundManager);
			_levelController.LoadLevel(levelNumber);

		}
		public override void Exit()
		{

		}
		public override void Update(float deltaTime)
		{
			_musicManager.Update(deltaTime);
			_levelController.Update(deltaTime);
		}
		public override void Draw()
		{
			StateMachine.Game.GraphicsDevice.SetRenderTarget(_screen);
			StateMachine.Game.GraphicsDevice.Clear(_backgroundColor);

			_spriteBatch.Begin(sortMode: SpriteSortMode.BackToFront);
			_levelController.Draw(_spriteBatch);
			_spriteBatch.Draw(_blackLine, new Vector2(0, 13 * 16), Color.Black);
			_spriteBatch.End();

			StateMachine.Game.GraphicsDevice.SetRenderTarget(null);

			_spriteBatch.Begin(samplerState: SamplerState.PointClamp);
			//_spriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.Deferred, effect: _shader);
			_spriteBatch.Draw(_screen, new Rectangle(0, 0, (15 * 16) * ScreenSizeMultiplier, (15 * 16) * ScreenSizeMultiplier), Color.White);
			_spriteBatch.End();		
		}
	}
}
