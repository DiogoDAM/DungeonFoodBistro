using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Behaviours
{
    public abstract class GameEntity : GameObject
    {
		public Transform Transform;
		public Vector2 Origin;
		public Color Color;
		public SpriteEffects SpriteEffect;
		public float Depth;
		public Sprite Sprite { get; protected set; }

		public GameEntity()
		{
			Transform = new();
			Origin = Vector2.Zero;
			Color = Color.White;
			SpriteEffect = SpriteEffects.None;
			Depth = 1f;
		}

		public override void Start()
		{
		}

        public override void Update()
        {
        }

        public override void Draw()
        {
			Globals.SpriteBatch.Draw(Sprite.Texture, Transform.Position, Sprite.Bounds, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
        }

		protected new void Dispose(bool disposable)
		{
			if(disposable)
			{
				if(!_disposed)
				{
					Sprite.Dispose();

					_disposed = true;
				}
			}
		}

    }
}
