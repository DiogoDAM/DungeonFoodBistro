using SuMamaLib.Utils;

using Microsoft.Xna.Framework;
using SuMamaLib.Collisions.Interfaces;
using System;

namespace SuMamaLib.Collisions
{
	public class BoxCollisor : ICollisor
	{
		public Transform Transform { get; set; }
		public int Width, Height;
		public IBody Body { get;  set;}

		public Rectangle BoundingRectangle { get => new Rectangle((int)Transform.Position.X, (int)Transform.Position.Y, Width, Height); }

		public Vector2 Center { get => new Vector2(Transform.Position.X + Width/2, Transform.Position.Y + Height/2); }

		public Vector2 TopLeft { get => new Vector2(Transform.Position.X); }
		public Vector2 TopRight { get => new Vector2(Transform.Position.X + Width); }
		public Vector2 BottomLeft { get => new Vector2(Transform.Position.Y); }
		public Vector2 BottomRight { get => new Vector2(Transform.Position.Y + Height); }

		public BoxCollisor(Transform transform, int w, int h)
		{
			Transform = transform;
			Width = w;
			Height = h;
		}

		public BoxCollisor(Vector2 pos, int w, int h)
		{
			Transform = new Transform(pos);
			Width = w;
			Height = h;
		}

		public Rectangle GetIntersection(BoxCollisor other)
		{
			return Rectangle.Intersect(this.BoundingRectangle, other.BoundingRectangle);
		}

		public static Rectangle GetIntersection(BoxCollisor a, BoxCollisor b)
		{
			return Rectangle.Intersect(a.BoundingRectangle, b.BoundingRectangle);
		}

		public bool Intersects(ICollisor other)
		{
			if(other is BoxCollisor)
			{
				return Intersects(this, other as BoxCollisor);
			}
			else if(other is CircleCollisor)
			{
				return Intersects(this, other as CircleCollisor);
			}
			else
			{
				return false;
			}
		}

		public static bool Intersects(BoxCollisor a, BoxCollisor b)
		{
			float ax = a.Transform.Position.X;
			float ay = a.Transform.Position.Y;
			float bx = b.Transform.Position.X;
			float by = b.Transform.Position.Y;

			return ax < bx + b.Width && ax + a.Width > bx &&
				ay < by + b.Height && ay + a.Height > by;
		}

		public static bool Intersects(BoxCollisor rect, CircleCollisor circle)
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
