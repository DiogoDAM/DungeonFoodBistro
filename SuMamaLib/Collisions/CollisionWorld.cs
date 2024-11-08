using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public sealed class CollisionWorld
	{
		private QuadTree _qt;
		private List<BoxCollisor> _collisions;
		private Rectangle _bounds;

		public int CollisorQuantity { get => _qt.Count; }

		public CollisionWorld(Rectangle boundary)
		{
			_bounds = boundary;
			_qt = new(_bounds, 25, 5);
			_collisions = new();
		}

		public void Update()
		{
			foreach(var collision in _collisions)
			{
				collision.Update();
			}

			foreach(var collision in _collisions)
			{
				if(collision is MovableCollisor)
				{
					_qt.Remove(collision);
					_qt.Insert(collision);
				}

				List<BoxCollisor> found = new();
				_qt.Query(collision, found);

				collision.UpdateCollisions(found);
			}
		}

		public void Draw()
		{
			foreach(var collision in _collisions)
			{
				if(collision is StaticCollisor)
				{
					Drawer.DrawLineRectangle(collision.Bounds, Color.Red, 3);
				}
				else if(collision is MovableCollisor)
				{
					Drawer.DrawLineRectangle(collision.Bounds, Color.Green, 2);
				}
			}
		}

		public void Add(BoxCollisor collisor)
		{
			if(_bounds.Intersects(collisor.Bounds))
			{
				_qt.Insert(collisor);
				_collisions.Add(collisor);
			}
		}

		public BoxCollisor Create(Vector2 pos, int w, int h, bool isStatic=true)
		{
			BoxCollisor newCollisor = new(pos, w, h);

			if(_bounds.Intersects(newCollisor.Bounds))
			{
				_qt.Insert(newCollisor);
				_collisions.Add(newCollisor);
			}

			return newCollisor;
		}

		public void Remove(BoxCollisor collisor)
		{
			if(_qt.Remove(collisor))
			{
				_collisions.Remove(collisor);
			}
		}

		public void Destroy(BoxCollisor collisor)
		{
			if(_qt.Remove(collisor))
			{
				_collisions.Remove(collisor);

				var removed = _collisions.Find(c => c.Equals(collisor));
				_collisions.Remove(collisor);
				removed.Dispose();
			}
		}

		public void Clear()
		{
			_qt.Clear();
		}

	}
}
