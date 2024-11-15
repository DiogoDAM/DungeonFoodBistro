using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuMamaLib.Utils.Sprites
{
	public class NineSlice
	{
		public Texture2D Texture { get; private set; }
		public Rectangle Bounds;

		private Rectangle _topLeft, _topMiddle, _topRight;
		private Rectangle _midLeft, _midMiddle, _midRight;
		private Rectangle _bottomLeft, _bottomMiddle, _bottomRight;

		// Thats values represent the repetition of each axis
		public int RepetitionX, RepetitionY;
		public int Width, Height;

		public NineSlice(Texture2D texture, Rectangle bounds, int repX, int repY)
		{
			if(texture != null) throw new NullReferenceException();
			Texture = texture;

			RepetitionX = repX;
			RepetitionY = repY;

			Width = bounds.Width/3;
			Height = bounds.Height/3;

			Bounds = bounds;

			int x = bounds.Location.X;
			int y = bounds.Location.Y;
			int width = Bounds.Width/3;
			int height = Bounds.Height/3;

			_topLeft = new(x, y, width, height);
			_topMiddle = new(x + width, y, width, height);
			_topRight = new(x + width * 2, y, width, height);

			_midLeft = new(x, y + height, width, height);
			_midMiddle = new(x + width, y + height, width, height);
			_midRight = new(x + width * 2, y + height, width, height);

			_bottomLeft = new(x, y + height * 2, width, height);
			_bottomMiddle = new(x + width, y + height * 2, width, height);
			_bottomRight = new(x + width * 2, y + height * 2, width, height);
		}

		public void Draw(Vector2 pos, float rot, Color color, Vector2 origin, Vector2 scale, SpriteEffects se, float depth)
		{
			//Top
			Globals.SpriteBatch.Draw(Texture, pos, _topLeft, color, rot, origin, scale, se, depth);
			for(int i=1; i<RepetitionX; i++)
			{
				Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X + (Width * i), (int)pos.Y), _topMiddle, color, rot, origin, scale, se, depth);
			}
			Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X + (Width * RepetitionX), (int)pos.Y), _topRight, color, rot, origin, scale, se, depth);

			//Middle
			for(int y=1; y<RepetitionY; y++)
			{
				Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X, (int)pos.Y + (Height * y)), _midLeft, color, rot, origin, scale, se, depth);
				for(int x=1; x<RepetitionX; x++)
				{
					Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X + (Width * x), (int)pos.Y + (Height * y)), _midMiddle, color, rot, origin, scale, se, depth);
				}
				Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X, (int)pos.Y + (Height * y)), _midRight, color, rot, origin, scale, se, depth);
			}

			//Bottom
			Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X, (int)pos.Y + (Height * RepetitionY)), _bottomLeft, color, rot, origin, scale, se, depth);
			for(int i=1; i<RepetitionX; i++)
			{
				Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X + (Width * i), (int)pos.Y + (Height * RepetitionY)), _bottomMiddle, color, rot, origin, scale, se, depth);
			}
			Globals.SpriteBatch.Draw(Texture, new Vector2((int)pos.X + (Width * RepetitionX), (int)pos.Y + (Height * RepetitionY)), _bottomRight, color, rot, origin, scale, se, depth);
		}
	}
}
