using System;
using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions.Interfaces
{
	public interface ICollisor : IDisposable
	{
		public Transform Transform { get; set; }
		public Rectangle BoundingRectangle { get;}
		public IBody Body { get; set; }

		public bool Intersects(ICollisor other);
	}
}
