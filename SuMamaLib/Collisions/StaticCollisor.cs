using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Collisions
{
    public class StaticCollisor : BoxCollisor
    {
        public StaticCollisor(Transform transform, int w, int h) : base(transform, w, h)
        {
			Mass = 1f;
        }

        public StaticCollisor(Vector2 pos, int w, int h) : base(pos, w, h)
        {
			Mass = 1f;
        }
    }
}
