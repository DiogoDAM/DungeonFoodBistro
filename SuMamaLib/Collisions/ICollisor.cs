using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
	public interface ICollisor
	{
		public Transform Transform { get; set; }
		public Rectangle Bounds { get; set; }

		public Vector2 Position { get => Transform.Position; set => Transform.Position = value; }


		public bool CheckCollision(ICollisor collisor);
	}
}
