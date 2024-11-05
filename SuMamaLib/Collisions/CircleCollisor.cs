using System;
using Microsoft.Xna.Framework;

using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class CircleCollisor : ICollisor
	{
		public Transform Transform { get; set; }
		public int Radius { get; set; }

		public Vector2 Center { get => Transform.Position; } 
		public Rectangle BoundingRectangle { get => new Rectangle((int)Center.X - Radius, (int)Center.Y - Radius, Diameter, Diameter);}
		public int Diameter { get => Radius * 2; }
		public float Circuference { get => 2 * (float)Math.PI * Radius; }

		public CircleCollisor(Vector2 pos, int radius)
		{
			Transform = new(pos);
			Radius = radius;
		}

		public CircleCollisor(Transform transform, int radius)
		{
			Transform = transform;
			Radius = radius;
		}

		public bool Intersects(ICollisor other)
		{
			if(other is CircleCollisor)
			{
				return Intersects(other as CircleCollisor);
			}
			else
			{
				return false;
			}
		}

		public bool Intersects(CircleCollisor other)
		{
			return Intersects(this, other);
		}

		public static bool Intersects(CircleCollisor a, CircleCollisor b)
		{
			int radiusSum = a.Radius + b.Radius;
			float distanceCenters = Vector2.Distance(a.Center, b.Center);

			return radiusSum > (int)distanceCenters;
		}
    }
}
