using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public interface ICollisor
	{
		public Transform Transform { get; set; }
		public Rectangle BoundingRectangle { get;}

		public bool Intersects(ICollisor other);
	}
}
