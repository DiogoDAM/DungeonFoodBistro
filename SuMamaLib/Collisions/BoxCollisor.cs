using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
    public class BoxCollisor : ICollisor
    {
        public Transform Transform { get; set; }
		public Rectangle Bounds { get; set; }

		public Vector2 Position { get => Transform.Position; set => Transform.Position = value; }
		public int Width { get; set; }


        public bool CheckCollision(ICollisor collisor)
        {
            throw new System.NotImplementedException();
        }
    }
}
