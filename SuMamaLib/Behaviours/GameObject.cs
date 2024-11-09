using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Interfaces;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Behaviours
{
    public abstract class GameObject : IDraw, IUpdate, IDisposableObject 
    {
		public Transform Transform;
		public Vector2 Origin;
		public Color Color;
		public SpriteEffects SpriteEffect;
		public float Depth;
		public Sprite Sprite { get; protected set; }
		public int Layer;

        public bool Disposed { get; protected set;}

		public GameObject()
		{
			Transform = new();
			Origin = Vector2.Zero;
			Color = Color.White;
			SpriteEffect = SpriteEffects.None;
			Depth = 1f;
			Layer = 0;
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
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool disposable)
		{
			if(disposable)
			{
				Disposed = true;
			}
		}

    }
}
