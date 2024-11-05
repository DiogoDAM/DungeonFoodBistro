using System;
using SuMamaLib.Behaviours;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class CollisionArgs
	{
		public RigidBody RigidBody { get; private set; }
		public ICollisor Collisor { get => RigidBody.Collisor;}
		public Transform Transform { get; set; }
		public GameObject GameObject { get; private set; }

		public CollisionArgs(RigidBody rb, Transform t)
		{
			RigidBody = rb;
			Transform = t;
		}

		public CollisionArgs(RigidBody rb, Transform t, GameObject go)
		{
			RigidBody = rb;
			Transform = t;
			GameObject = go;
		}

		public void SetData(GameObject go)
		{
			if(go == null){ throw new NullReferenceException(); }

			GameObject = go;
		}
	}
}
