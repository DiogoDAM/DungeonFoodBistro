using System;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions.Interfaces;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class CollisionArgs
	{
		public RigidBody RigidBody { get; private set; }
		public ICollisor Collisor { get;}
		public Transform Transform { get; set; }
		public GameObject GameObject { get; private set; }

		public CollisionArgs(RigidBody rb, ICollisor collisor, Transform t)
		{
			RigidBody = rb;
			Collisor = collisor;
			Transform = t;
		}

		public CollisionArgs(RigidBody rb, ICollisor collisor, Transform t, GameObject go)
		{
			RigidBody = rb;
			Collisor = collisor;
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
