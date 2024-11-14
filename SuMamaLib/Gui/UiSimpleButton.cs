using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Inputs;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Interfaces;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Gui
{
	public class UiButton : UiComponent, IClickable
	{
		public Rectangle Bounds { get; set; }

		public event Action CursorHover;
		public event Action CursorEndHover;
		public event Action CursorClick;
		public event Action CursorEndClick;
		public event Action CursorClicking;

		private bool _cursorHover;
		private bool _cursorClicking;

		public UiButton() : base()
		{
			Bounds = new Rectangle(0,0, 100, 10);
		}

		public UiButton(Rectangle bounds, Color color)
		{
			Bounds = bounds;
			Color = color;
		}

		public UiButton(Vector2 pos, int w, int h, Color color)
		{
			Bounds = new Rectangle(pos.ToPoint(), new Point(w,h));
			Color = color;
		}

		public override void Update()
		{
			CheckCursorEvents();
			base.Update();
		}

		public override void Draw()
		{
			Drawer.DrawFillRectangle(Bounds, Color);
			base.Draw();
		}

		private void CheckCursorEvents()
		{
			if(Bounds.Contains(Input.Mouse.Position))
			{
				CursorHover?.Invoke();
				_cursorHover = true;
			}

			if(_cursorHover && !Bounds.Contains(Input.Mouse.Position))
			{
				CursorEndHover?.Invoke();
				_cursorHover = false;
			}

			if(_cursorHover && Input.Mouse.LmbIsPressed())
			{
				CursorClicking?.Invoke();
				_cursorClicking = true;
			}

			if(_cursorHover && Input.Mouse.LmbWasPressed())
			{
				CursorClick?.Invoke();
			}

			if(_cursorHover && Input.Mouse.LmbWasReleased())
			{
				CursorEndClick?.Invoke();
				_cursorClicking = true;
			}

		}
	}
}
