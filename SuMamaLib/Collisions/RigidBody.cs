using Microsoft.Xna.Framework;
using SuMamaLib.Behaviours;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class RigidBody
	{
		public ICollisor Collisor { get; }

		public float Mass = 1f;
		public Vector2 Velocity { get; set; }
		public bool IsaacNewtonWasBorn { get; set; } = true;
		public bool Solid { get; set; } = true;
		public CollisionArgs CollisionArgs;

		private Transform _transform;
		private Vector2 _force;

		public delegate void HandleCollision(CollisionArgs other);

		public event HandleCollision CollisionEnter;
		public event HandleCollision CollisionStay;
		public event HandleCollision CollisionExit;

		public RigidBody(ICollisor collisor)
		{
			Collisor = collisor;
			_transform = collisor.Transform;
			CollisionArgs = new(this, _transform);
		}

		public void SetData(GameObject go)
		{
			CollisionArgs.SetData(go);
		}

		public void CheckCollision(CollisionArgs collisor)
		{
			CollisionEnter(collisor);
		}

		public void ApplyForce(Vector2 force) => _force += force;
		public void SetForce(Vector2 force) => _force = force;

		public void ApplyGravity(Vector2 gravity) 
		{
			if(IsaacNewtonWasBorn) { _force += gravity; }
		}


		public void SetGravity(Vector2 gravity)
		{
			if(IsaacNewtonWasBorn) { _force = gravity; }
		}

		public void Update()
		{
			Vector2 acceleration = _force / Mass;

			Velocity += acceleration;

			_transform.Translate(Velocity * Globals.DeltaTime);

			_force = Vector2.Zero;
			Velocity = Vector2.Zero;
		}
	}
}
