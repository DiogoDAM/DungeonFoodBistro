using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions.Interfaces;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class RigidBody : IBody
	{
		public ICollisor Collisor { get; }

		public float Mass = 1f;
		public Vector2 Velocity { get; set; }
		public bool IsaacNewtonWasBorn { get; set; } = true;
		public bool Solid { get; set; } = true;
        public CollisionArgs CollisionArgs { get; }
		public Transform Transform { get; }

        private Vector2 _force;
		private Dictionary<ICollisor, bool> _contacts;

		public delegate void HandleCollision(CollisionArgs other);

		public event HandleCollision CollisionEnter;
		public event HandleCollision CollisionStay;
		public event HandleCollision CollisionExit;

		public RigidBody(ICollisor collisor)
		{
			Collisor = collisor;
			Transform = collisor.Transform;
			Collisor.Body = this;
			CollisionArgs = new(this, collisor, Transform);

			_contacts = new();
		}

		public void SetData(GameObject go)
		{
			CollisionArgs.SetData(go);
		}

		public void UpdateCollision(ICollisor other, bool isColliding)
		{
			if(other == null) throw new NullReferenceException();

			if(!_contacts.ContainsKey(other))
			{
				_contacts.Add(other, isColliding);
			}

			//Check to Enter
			if(_contacts[other] == false && isColliding)
			{
				CollisionEnter.Invoke(other.Body.CollisionArgs);
			}

			//Check to Stay
			if(_contacts[other] == true && isColliding)
			{
				CollisionStay.Invoke(other.Body.CollisionArgs);
			}

			//Check to Exit
			if(_contacts[other] == true && !isColliding)
			{
				CollisionExit.Invoke(other.Body.CollisionArgs);
			}

			_contacts[other] = isColliding;
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
	}
}
