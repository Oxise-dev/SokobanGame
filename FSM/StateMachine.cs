using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace SocobanGame.FSM
{
	class StateMachine
	{
		private Dictionary<string, IState> _states = new Dictionary<string, IState>();
		private IState _currentState;
		public StateMachine(Game game)
		{
			Game = game;
		}
		public Game Game { get; }
		public void Change(string stateName)
		{
			if (!_states.ContainsKey(stateName))
				throw new KeyNotFoundException($"{stateName} is not a valid state!");

			if (_currentState != null)
			{
				_currentState.Exit();
			}
			_currentState = _states[stateName];

			_currentState.Enter();
		}
		public void Add(string stateName, IState state)
		{
			_states.Add(stateName, state);
		}
		public void Remove(string stateName)
		{
			if (!_states.ContainsKey(stateName))
				throw new KeyNotFoundException($"{stateName} is not a valid state!");

			_states.Remove(stateName);
		}
		public void Draw()
		{
			if (_currentState != null)
				_currentState.Draw();
		}
		public void Update(float deltaTime)
		{
			if (_currentState != null)
				_currentState.Update(deltaTime);
		}
	}
}
