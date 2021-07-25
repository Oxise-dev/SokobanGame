using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocobanGame.Colision
{
	interface IColideable
	{
		public ColisionManager ColisionManager { get; set; }
		string Tag { get; set; }
		Rectangle Rectangle { get; }
	}
}
