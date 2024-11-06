using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions.Interfaces;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class RigidBody : IBody, IDisposable
	{
		public ICollisor Collisor { get; }

		public float Mass = 1f;
		public Vector2 Velocity { get; set; }
		public bool IsaacNewtonWasBorn { get; set; } = true;
		public bool Solid { get; set; } = true;
        public CollisionEventArgs CollisionEventArgs { get; }
		public Transform Transform { get; }

        private Vector2 _force;
		private HashSet<IBody> _currCollisions;
		private bool _disposed;

		public delegate void HandleCollision(CollisionEventArgs other);

		public event HandleCollision CollisionEnter;
		public event HandleCollision CollisionStay;
		public event HandleCollision CollisionExit;

		public RigidBody(ICollisor collisor)
		{
			Collisor = collisor;
			Transform = collisor.Transform;
			Collisor.Body = this;
			CollisionEventArgs = new(this, collisor, Transform);

			_currCollisions = new();
		}

		public void SetData(GameObject go)
		{
			CollisionEventArgs.SetData(go);
		}

		public void UpdateCollision(IEnumerable<IBody> possibleCollisions)
		{
			var newCollisions = new HashSet<IBody>();

			foreach(var other in possibleCollisions)
			{
				if(this != other && this.Collisor.Intersects(other.Collisor))
				{
					newCollisions.Add(other);

					if(!_currCollisions.Contains(other))
					{
						CollisionEnter?.Invoke(other.CollisionEventArgs);
					}
					else
					{
						CollisionStay?.Invoke(other.CollisionEventArgs);
					}
				}
			}

			foreach(var currCollision in _currCollisions)
			{
				if(!newCollisions.Contains(currCollision))
				{
					CollisionExit?.Invoke(currCollision.CollisionEventArgs);
				}
			}

			_currCollisions = newCollisions;
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

			Transform.Translate(Velocity * Globals.DeltaTime);

			_force = Vector2.Zero;
			Velocity = Vector2.Zero;
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
					Collisor.Dispose();
					_disposed = true;
				}
			}
		}
	}
}
