using System;
using Microsoft.Xna.Framework;

namespace SuMamaLib.Utils.Interfaces
{
	public interface IClickable
	{
		public event Action CursorHover;
		public event Action CursorEndHover;
		public event Action CursorClick;
		public event Action CursorClicking;
		public event Action CursorEndClick;

		public Rectangle Bounds { get; }
	}
}
