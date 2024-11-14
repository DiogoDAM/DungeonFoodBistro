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

		public Vector2 Position ;
		public Color Color;
		public Vector2 Scale;
		public SpriteEffects SpriteEffect;

		public Vector2 TextSize { get => Font.MeasureString(Text); }

		public SpriteText(SpriteFont font, int size, Vector2 pos)
		{
			SetFont(font, size);
			SetText("Lorem Ipsum");
			Position = pos;
			Color = Color.Black;
			Scale = Vector2.One;
			SpriteEffect = SpriteEffects.None;
		}

		public SpriteText(SpriteFont font, int size, string text, Vector2 pos)
		{
			SetFont(font, size);
			SetText(text);
			Position = pos;
			Color = Color.Black;
			Scale = Vector2.One;
			SpriteEffect = SpriteEffects.None;
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
