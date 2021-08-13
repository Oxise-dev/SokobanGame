using Microsoft.Xna.Framework;
using SocobanGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Turns
{
	class TurnsManager
	{
		private readonly GameObject _gameObject;
		private readonly List<Vector2> _turns = new List<Vector2>();
		public TurnsManager(GameObject owner)
		{
			_gameObject = owner; 
			_turns.Add(_gameObject.Position);
			_turns.Add(_gameObject.Position);

		}
		public void Add(Vector2 turn)
		{
			_turns.Add(turn);
		}
		public void Revert()
		{
			if (_turns.Count > 2)
			{
				_gameObject.Position = _turns[_turns.Count - 1];
				_turns.RemoveAt(_turns.Count - 1);
			}
			else
				_gameObject.Position = _turns[_turns.Count - 1];

		}
	}
}
