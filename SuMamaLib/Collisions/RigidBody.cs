using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class RigidBody
	{
		public ICollisor Collisor { get; }

		public Vector2 Acceleration;
		public Vector2 Velocity;

		public float Mass = 1f;
		public float Friction { get; set; }=1f;
		
		private Transform _transform;

		public RigidBody(ICollisor collisor)
		{
			Collisor = collisor;
			_transform = collisor.Transform;
		}

		public void ApplyForce(Vector2 force)
		{
			Acceleration += force / Mass;
		}

		public void ApplyGravity(Vector2 gravity)
		{
			Acceleration += gravity;
		}

		public void Update()
		{
			Velocity += Acceleration * Globals.DeltaTime;
			Acceleration = Vector2.Zero;

			Velocity *= 1 - Friction * Globals.DeltaTime;

			_transform.Translate(Velocity * Globals.DeltaTime);

		}
	}
}
