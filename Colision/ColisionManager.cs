using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Colision
{
	public class ColisionManager
	{
		public List<IColideable> Colideables = new List<IColideable>();
		public ColisionManager()
		{

		}
		public void Update()
		{

		}
		public void Clear()
		{
			foreach (var colideable in Colideables)
			{
				colideable.ColisionManager = null;
			}

			Colideables.Clear();
		}
		public void Add(IColideable colideable)
		{
			if (colideable != null)
			{
				Colideables.Add(colideable);
				colideable.ColisionManager = this;
			}

		}
		public void Remove(IColideable colideable)
		{
			if (Colideables.Contains(colideable))
			{
				Colideables.Remove(colideable);
				colideable.ColisionManager = null;
			}
		}
	}
}
