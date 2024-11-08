using Microsoft.Xna.Framework;
using SuMamaLib.Behaviours;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public sealed class CollisionEventArgs
	{
		public BoxCollisor Collisor;
		public GameObject GameObject;
		public Transform Transform;

		public Vector2 Position { get => Transform.Position; set => Transform.Position = value; }

		public CollisionEventArgs(BoxCollisor collisor, Transform transform)
		{
			Collisor = collisor;
			Transform = transform;
			GameObject = null;
		}

		public void SetGameObj(GameObject gameObj)
		{
			if(gameObj == null) throw new System.NullReferenceException();

			GameObject = gameObj;
		}
	}
}
