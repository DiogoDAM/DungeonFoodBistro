using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SuMamaLib.Behaviours.Interfaces;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Behaviours
{
    public abstract class GameObject : IDraw, IUpdate, IDisposable
    {
		protected bool _disposed = false;

		public Transform Transform;
		public Vector2 Origin;
		public Color Color;
		public SpriteEffects SpriteEffect;
		public float Depth;
		public Sprite Sprite { get; private set; }

		public GameObject()
		{
			Transform = new();
			Origin = Vector2.Zero;
			Color = Color.White;
			SpriteEffect = SpriteEffects.None;
			Depth = 0f;
		}

		public virtual void Start()
		{
		}

        public virtual void Update()
        {
        }

        public virtual void Draw()
        {
			Globals.SpriteBatch.Draw(Sprite.Texture, Transform.Position, Sprite.Bounds, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
        }

        public void Dispose()
        {
			Dispose(true);
        }

		protected void Dispose(bool disposable)
		{
			if(disposable)
			{
				if(!_disposed)
				{
					_disposed = true;
				}
			}
		}
    }
}
