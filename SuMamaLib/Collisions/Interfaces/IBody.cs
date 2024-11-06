using System;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions.Interfaces
{
	public interface IBody : IDisposable
	{
		public ICollisor Collisor { get; }
		public CollisionEventArgs CollisionEventArgs { get; }
		public Transform Transform { get; }
	}
}
