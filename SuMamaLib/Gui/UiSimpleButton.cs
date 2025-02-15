using System;
using Microsoft.Xna.Framework;
using SuMamaLib.Inputs;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Interfaces;

namespace SuMamaLib.Gui
{
	public class UiSimpleButton : UiComponent, IClickable
	{
		public Rectangle Bounds { get => new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }

		public event Action CursorHover;
		public event Action CursorEndHover;
		public event Action CursorClick;
		public event Action CursorEndClick;
		public event Action CursorClicking;

		private bool _cursorHover;
		private bool _cursorClicking;

		public UiSimpleButton() : base()
		{
		}

		public UiSimpleButton(Rectangle bounds, Color color)
		{
			Transform.Position = bounds.Location.ToVector2();
			Width = bounds.Width;
			Height = bounds.Height;
			Color = color;
		}

		public UiSimpleButton(int w, int h, Color color)
		{
			Transform.Position = Vector2.Zero;
			Width = w;
			Height = h;
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

			if(_cursorClicking && _cursorHover && Input.Mouse.LmbWasReleased())
			{
				CursorEndClick?.Invoke();
				_cursorClicking = false;
			}

		}
	}
}
