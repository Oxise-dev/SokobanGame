using Microsoft.Xna.Framework;
using SocobanGame.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Turns
{
	class Turn
	{
		private int _currentTurnNumber = 0;
		private GameObject _gameObject;
		private List<Vector2> _turns = new List<Vector2>();
		public Turn(GameObject owner)
		{
			_gameObject = owner;
		}
		public void Add(Vector2 turn)
		{
			_turns.Add(turn);
			_currentTurnNumber++;
		}
		public void Revert()
		{
			//if (_currentTurnNumber - 1 >= 0)
			//{
			//	_gameObject.Position = _turns[_currentTurnNumber - 1];
			//	_turns.Remove(_turns[_currentTurnNumber - 1]);
			//	_currentTurnNumber--;
			//}	
		}
	}
}
