using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuMamaLib.Collisions.Interfaces;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public class CollisionWorld
	{
		private QuadTree _qt;
		private List<RigidBody> _rbList;
		private Rectangle _bounds;
		// private List<StaticBody> _sbList;

		public CollisionWorld(Rectangle boundary)
		{
			_qt = new(boundary, 25, 5);
			_bounds = boundary;
			_rbList = new();
		}

		public void Update()
		{
			foreach(var rb in _rbList)
			{
				rb.Update();
			}

			CheckCollisions();
		}

		public void Draw()
		{
			foreach(var rb in _rbList)
			{
				Drawer.DrawLineRectangle(rb.Collisor.BoundingRectangle, Color.Green, 2);
			}
		}

		public void AddBody(IBody body)
		{
			if(body == null) throw new NullReferenceException();
			if(!body.Collisor.BoundingRectangle.Intersects(_bounds)) return;

			if(body is RigidBody)
			{
				_rbList.Add(body as RigidBody);
			}

			_qt.Insert(body);
		}

		public void RemoveBody(IBody body)
		{
			if(body == null) throw new NullReferenceException();

			if(body is RigidBody)
			{
				_rbList.Remove(body as RigidBody);
			}
		}

		public void DestroyBody(IBody body)
		{
			if(body == null) throw new NullReferenceException();

			if(body is RigidBody)
			{
				var removedBody = _rbList.Find(b => b.Equals(body));
				_rbList.Remove(body as RigidBody);
				removedBody.Dispose();
			}
		}

		private void CheckCollisions()
		{
			foreach(var rb in _rbList)
			{
				var found = new List<IBody>();
				_qt.Query(rb, found);

				rb.UpdateCollision(found);
			}

			ReInsertAllMovableBodys();
		}

		private void ReInsertAllMovableBodys()
		{
			foreach(var rb in _rbList)
			{
				_qt.Remove(rb);
				_qt.Insert(rb);
			}


		}

	}
}
