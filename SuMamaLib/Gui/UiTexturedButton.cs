using System;
using Microsoft.Xna.Framework;
using SuMamaLib.Inputs;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Interfaces;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Gui
{
	public class UiTexturedButton : UiComponent, IClickable
	{
		public Rectangle Bounds { get => new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }
		public Sprite Sprite { get; }

		public event Action CursorHover;
		public event Action CursorEndHover;
		public event Action CursorClick;
		public event Action CursorEndClick;
		public event Action CursorClicking;

		private bool _cursorHover;
		private bool _cursorClicking;

		public UiTexturedButton() : base()
		{
			Sprite = null;
		}

		public UiTexturedButton(Sprite sprite, Rectangle bounds, Color color)
		{
			Sprite = sprite;
			Transform.Position = bounds.Location.ToVector2();
			Width = bounds.Width;
			Height = bounds.Height;
			Color = color;
		}

		public UiTexturedButton(Sprite sprite, int w, int h, Color color)
		{
			Sprite = sprite;
			Transform.Position = Vector2.Zero;
			Width = w;
			Height = h;
			Color = color;
		}

		public void SearchSpriteFrame(Point srcPos, Point srcSize)
		{
			Sprite.StartPos = srcPos;
			Sprite.Size = srcSize;
		}

		public void SearchSpriteFrame(Rectangle srcRect)
		{
			Sprite.StartPos = srcRect.Location;
			Sprite.Size = srcRect.Size;
		}

		public override void Update()
		{
			CheckCursorEvents();
			base.Update();
		}

		public override void Draw()
		{
			Globals.SpriteBatch.Draw(Sprite.Texture, Position, Sprite.Bounds, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);

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
