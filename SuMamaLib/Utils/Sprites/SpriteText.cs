using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuMamaLib.Utils.Sprites
{
	public sealed class SpriteText
	{
		public SpriteFont Font { get; private set; }
		public int FontSize { get; private set; }
		public string Text { get; private set; }

		public Vector2 Position { get; set; }
		public Vector2 Offset { get; set; }
		public float Rotation { get; set; }
		public Vector2 Origin { get; set; }
		public Color Color { get; set; }
		public Vector2 Scale { get; set; }
		public SpriteEffects SpriteEffect { get; set; }
		public float Depth { get; set; }

		public int TextSize { get => Text.Length * FontSize; }

		public SpriteText(SpriteFont font, int size, Vector2 pos)
		{
			SetFont(font, size);
			SetText("Lorem Ipsum");
			Position = pos;
			Offset = Vector2.Zero;
			Rotation = 0f;
			Origin = Vector2.Zero;
			Color = Color.Black;
			Scale = Vector2.One;
			SpriteEffect = SpriteEffects.None;
			Depth = 0f;
		}

		public SpriteText(SpriteFont font, int size, string text, Vector2 pos)
		{
			SetFont(font, size);
			SetText(text);
			Position = pos;
			Offset = Vector2.Zero;
			Rotation = 0f;
			Origin = Vector2.Zero;
			Color = Color.Black;
			Scale = Vector2.One;
			SpriteEffect = SpriteEffects.None;
			Depth = 0f;
		}

		public SpriteText(SpriteFont font, int size, string text, Vector2 pos, float depth)
		{
			SetFont(font, size);
			SetText(text);
			Position = pos;
			Offset = Vector2.Zero;
			Rotation = 0f;
			Origin = Vector2.Zero;
			Color = Color.Black;
			Scale = Vector2.One;
			SpriteEffect = SpriteEffects.None;
			Depth = depth;
		}

		public void SetFont(SpriteFont font, int size)
		{
			if(font == null) throw new NullReferenceException();
			Font = font;
			FontSize = size;
		}

		public void SetText(string text)
		{
			if(String.IsNullOrEmpty(text)) throw new NullReferenceException();
			Text = text;
		}
	}
}
