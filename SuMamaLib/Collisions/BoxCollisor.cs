using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Interfaces;

namespace SuMamaLib.Collisions
{
    public class BoxCollisor : IDisposableObject
    {
        public Transform Transform { get; set; }
		public Rectangle Bounds { get => new Rectangle(Transform.Position.ToPoint() + Offset, new Point(Width, Height)); }
		public CollisionEventArgs EventArgs { get; protected set; }
		public float Mass { get; set; }
		public bool Disposed { get; protected set; }
		public CollisionClass Class { get; set; }

		public Vector2 Position { get => Transform.Position; set => Transform.Position = value; }
		public int Width { get; }
		public int Height { get; }
		public Point Offset { get; set; }

		public int Left { get => Bounds.Left; }
		public int Right { get => Bounds.Right; }
		public int Top { get => Bounds.Top; }
		public int Bottom { get => Bounds.Bottom; }
		public Vector2 Center { get => Bounds.Center.ToVector2(); }

        HashSet<BoxCollisor> _currCollisors { get; set; }

		public delegate void HandleCollisionState(CollisionEventArgs args);

        public event HandleCollisionState CollisionEnter;
        public event HandleCollisionState CollisionStay;
        public event HandleCollisionState CollisionExit;

		public BoxCollisor(Transform transform, int w, int h)
		{
			Transform = transform;
			Width = w;
			Height = h;
			_currCollisors = new();
			Class = new();
		}

		public BoxCollisor(Vector2 pos, int w, int h)
		{
			Transform = new(pos);
			Width = w;
			Height = h;
			_currCollisors = new();
			Class = new();
		}

		public virtual void Update()
		{
		}

        public bool CheckCollision(BoxCollisor other)
        {
			return this.Bounds.Intersects(other.Bounds);
        }

        public void UpdateCollisions(IEnumerable<BoxCollisor> possibleCollisors)
        {
			var newCollisions = new HashSet<BoxCollisor>();

			foreach(var collisor in possibleCollisors)
			{
				if(collisor != this && (Class.CheckClassForCollision(collisor) || Class.CheckClassForCollisionSolid(collisor)))
				{
					newCollisions.Add(collisor);

					if(Class.CheckClassForCollisionSolid(collisor)) { ResolveCollision(collisor); }

					if(!_currCollisors.Contains(collisor))
					{
						CollisionEnter?.Invoke(EventArgs);
					}
					else
					{
						CollisionStay?.Invoke(EventArgs);
					}
				}
			}

			foreach(var collisor in _currCollisors)
			{
				if(!newCollisions.Contains(collisor))
				{
					CollisionExit?.Invoke(EventArgs);
				}
			}

			_currCollisors = newCollisions;
        }

		public void ResolveCollision(BoxCollisor other)
		{
			Rectangle intersection = Rectangle.Intersect(this.Bounds, other.Bounds);

			if(intersection.Width < intersection.Height)
			{
				if(other.Position.X < this.Position.X)
				{
					other.Transform.Position.X -= intersection.Width;
				}
				else
				{
					other.Transform.Position.X += intersection.Width;
				}
			}
			else
			{
				if(other.Position.Y < this.Position.Y)
				{
					other.Transform.Position.Y -= intersection.Height;
				}
				else
				{
					other.Transform.Position.Y += intersection.Height;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposable)
		{
			if(disposable)
			{
				EventArgs = null;
				Disposed = true;
			}
		}
    }
}
