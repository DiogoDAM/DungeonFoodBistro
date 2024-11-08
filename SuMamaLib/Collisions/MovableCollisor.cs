using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
    public class MovableCollisor : BoxCollisor
    {
		public Vector2 Velocity;

		private Vector2 _gravity;

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
			Velocity += _gravity / Mass;

			Position += Velocity * Globals.DeltaTime;

			Velocity = Vector2.Zero;
		}

		public void SetGravity(Vector2 gravity)
		{
			_gravity = gravity;
		}

		public void ApplyGravity(Vector2 gravity)
		{
			_gravity += gravity;
		}
    }
}
