using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Colision
{
	public interface IColideable
	{
		public ColisionManager ColisionManager { get; set; }
		Rectangle Rectangle { get; }
	}
}
