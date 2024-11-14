using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Inputs;
using SuMamaLib.Utils.Interfaces;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Gui
{
	public class UiButton : UiComponent, IClickable
	{
		public Rectangle Bounds { get; set; }
		public SpriteText Text;

		public event Action CursorHover;
		public event Action CursorEndHover;
		public event Action CursorClick;
		public event Action CursorEndClick;

		private bool _cursorHover;
		private bool _cursorClick;

		public UiButton() : base()
		{
			Bounds = new Rectangle(0,0, 100, 10);
			Text = null;
		}

		public UiButton(Rectangle bounds, SpriteFont font, int fontSize, string text, Color color)
		{
			Bounds = bounds;
			Text = new(font, fontSize, text, Vector2.Zero);
			Color = color;
		}

		public UiButton(Vector2 pos, int w, int h, SpriteFont font, int fontSize, string text, Color color)
		{
			Bounds = new Rectangle(pos.ToPoint(), new Point(w,h));
			Text = new(font, fontSize, text, Vector2.Zero);
			Color = color;
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw()
		{
			base.Draw();
		}

		private void CheckCursorEvents()
		{
			if(!_cursorHover && Bounds.Intersects(new Rectangle(Input.Mouse.Position.ToPoint(), new Point(1,1))))
			{
				CursorHover?.Invoke();
				_cursorHover = true;
			}

			if(_cursorHover && !Bounds.Intersects(new Rectangle(Input.Mouse.Position.ToPoint(), new Point(1,1))))
			{
				CursorEndHover?.Invoke();
			}

		}
	}
}
