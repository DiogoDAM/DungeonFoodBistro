using System.Collections.Generic;

namespace SuMamaLib.Collisions
{
	public class CollisionClass
	{
		public List<string> Classification;
		public List<string> Collision;
		public List<string> Solid;

		public CollisionClass()
		{
			Classification = new();
			Collision = new();
			Solid = new();
		}

		public CollisionClass(string myClass)
		{
			Classification = new();
			Classification.Add(myClass);
			Collision = new();
			Solid = new();
		}

		public CollisionClass(string myClass, string collision)
		{
			Classification = new();
			Classification.Add(myClass);
			Collision = new();
			Collision.Add(collision);
			Solid = new();
		}

		public bool CheckClassForCollision(CollisionClass other)
		{
			foreach(var c in other.Classification)
			{
				if(Collision.Contains(c))
				{
					return true;
				}
			}

			return false;
		}

		public bool CheckClassForCollision(BoxCollisor other)
		{
			foreach(var c in other.Class.Classification)
			{
				if(Collision.Contains(c))
				{
					return true;
				}
			}

			return false;
		}

		public bool CheckClassForCollisionSolid(CollisionClass other)
		{
			foreach(var c in other.Classification)
			{
				if(Solid.Contains(c))
				{
					return true;
				}
			}

			return false;
		}

		public bool CheckClassForCollisionSolid(BoxCollisor other)
		{
			foreach(var c in other.Class.Classification)
			{
				if(Solid.Contains(c))
				{
					return true;
				}
			}

			return false;
		}

	}
}
