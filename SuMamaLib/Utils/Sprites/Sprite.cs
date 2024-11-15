using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuMamaLib.Utils.Sprites
{
    public class Sprite : IDisposable
    {
        public Texture2D Texture { get; private set; }
        public Point StartPos;
        public Point Size;
		public Rectangle Bounds { get { return new Rectangle(StartPos, Size); } }
		private bool _disposed = false;

		public Sprite(Texture2D texture)
		{
			SetTexture(texture);
			StartPos = new Point(0,0);
			Size = new Point(texture.Width, texture.Height);
		}

        public Sprite(Texture2D texture, Rectangle rect)
        {
            SetTexture(texture);
            StartPos = new Point(rect.X, rect.Y);
            Size = new Point(rect.Width, rect.Height);
        }

        public Sprite(Texture2D texture, Point p, Point s)
        {
            SetTexture(texture);
            StartPos = p;
            Size = s;
        }

        public Sprite(Texture2D texture, Point p, int w, int h)
        {
            SetTexture(texture);
            StartPos = p;
            Size = new Point(w, h);
        }

        public void SetTexture(Texture2D texture)
        {
            if(texture == null) { throw new NullReferenceException("Texture is null");}
            Texture = texture;
        }

        public void Dispose()
        {
			Dispose(true);
			GC.SuppressFinalize(this);
        }

		private void Dispose(bool disposable)
		{
			if(disposable)
			{
				if(!_disposed)
				{
					Texture.Dispose();
					Texture = null;

					_disposed = true;
				}
			}
		}
    }

}
