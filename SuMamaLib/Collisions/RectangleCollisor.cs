using SuMamaLib.Utils;

using Microsoft.Xna.Framework;
using SuMamaLib.Collisions.Interfaces;

namespace SuMamaLib.Collisions
{
	public class RectangleCollisor : ICollisor
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

		public RectangleCollisor(Transform transform, int w, int h)
		{
			Transform = transform;
			Width = w;
			Height = h;
		}

		public RectangleCollisor(Vector2 pos, int w, int h)
		{
			Transform = new Transform(pos);
			Width = w;
			Height = h;
		}

		public Rectangle GetIntersection(RectangleCollisor other)
		{
			return Rectangle.Intersect(this.BoundingRectangle, other.BoundingRectangle);
		}

		public static Rectangle GetIntersection(RectangleCollisor a, RectangleCollisor b)
		{
			return Rectangle.Intersect(a.BoundingRectangle, b.BoundingRectangle);
		}

		public bool Intersects(ICollisor other)
		{
			if(other is RectangleCollisor)
			{
				return Intersects(other as RectangleCollisor);
			}
			else
			{
				return false;
			}
		}

		public bool Intersects(RectangleCollisor other)
		{
			return Intersects(this, other);
		}

		public static bool Intersects(RectangleCollisor a, RectangleCollisor b)
		{
			float ax = a.Transform.Position.X;
			float ay = a.Transform.Position.Y;
			float bx = b.Transform.Position.X;
			float by = b.Transform.Position.Y;

			return ax < bx + b.Width && ax + a.Width > bx &&
				ay < by + b.Height && ay + a.Height > by;
		}
    }
}
