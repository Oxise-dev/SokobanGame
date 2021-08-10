using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.GameObjects
{
	public class GoalsContainer
	{
		private List<Goal> _goals = new List<Goal>();

		public bool Completed { get; private set; } = false;
		
		public void Add(Goal goal)
		{
			_goals.Add(goal);
		}
		public void Remove(Goal goal)
		{
			if (_goals.Contains(goal))
				_goals.Remove(goal);
		}
		public void Clear()
		{
			_goals.Clear();
		}
		public void Update()
		{
			int filledGoals = 0;
			foreach (var goal in _goals)
			{
				var _gameObjects = goal.ColisionManager.GetMoveIntersections(goal, Vector2.Zero);
				if (_gameObjects.Count > 0)
				{
					foreach (var gameObject in _gameObjects)
					{
						if (gameObject.ID == GameObjectID.Box)
						{
							goal.IsOccupied = true;
							filledGoals++;
						}
					}
				}
				else
				{
					goal.IsOccupied = false;
					Completed = false;
				}
			}
			if (_goals.Count <= filledGoals)
				Completed = true;
			else
				Completed = false;
		}
	}
}
