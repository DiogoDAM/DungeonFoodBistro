using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
    public class MovableCollisor : BoxCollisor
    {
		public Vector2 Velocity;

        public MovableCollisor(Transform transform, int w, int h) : base(transform, w, h)
        {
			Mass = 1f;
        }

        public MovableCollisor(Vector2 pos, int w, int h) : base(pos, w, h)
        {
			Mass = 1f;
        }

		public override void Update()
		{
			Position += Velocity * Globals.DeltaTime;
		}

		public void ApplyGravity(Vector2 grav)
		{
			Velocity += grav;
		}

    }
}
