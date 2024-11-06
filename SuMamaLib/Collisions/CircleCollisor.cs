using System;
using Microsoft.Xna.Framework;
using SuMamaLib.Collisions.Interfaces;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class CircleCollisor : ICollisor
	{
		public Transform Transform { get; set; }
		public int Radius { get; set; }
		public IBody Body { get; set; }

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
				return Intersects(this, other as CircleCollisor);
			}
			else if(other is BoxCollisor)
			{
				return Intersects(this, other as BoxCollisor);
			}
			else
			{
				return false;
			}
		}

		public static bool Intersects(CircleCollisor a, CircleCollisor b)
		{
			int radiusSum = a.Radius + b.Radius;
			float distanceCenters = Vector2.Distance(a.Center, b.Center);

			return radiusSum > (int)distanceCenters;
		}

		public static bool Intersects(CircleCollisor circle, BoxCollisor rect)
		{
			float closeX = Math.Max(rect.TopLeft.X, Math.Min(circle.Radius, rect.TopRight.X));
			float closeY = Math.Max(rect.TopLeft.Y, Math.Min(circle.Radius, rect.BottomRight.Y));

			float distX = circle.Radius - closeX;
			float distY = circle.Radius - closeY;
			float distanceSquared = (distX*distX) + (distY*distY);

			return distanceSquared <= (circle.Radius * circle.Radius);
		}
    }
}
