using SuMamaLib.Utils;

using Microsoft.Xna.Framework;

namespace SuMamaLib.Collisions
{
	public class RectangleCollisor : ICollisor
	{
		public Transform Transform;
		public int Width, Height;

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


        public bool CheckCollision()
        {
            throw new System.NotImplementedException();
        }
    }
}
