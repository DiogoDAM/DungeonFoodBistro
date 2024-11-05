using SuMamaLib.Utils;

namespace SuMamaLib.Collisions.Interfaces
{
	public interface IBody
	{
		public ICollisor Collisor { get; }
		public CollisionArgs CollisionArgs { get; }
		public Transform Transform { get; }
	}
}
