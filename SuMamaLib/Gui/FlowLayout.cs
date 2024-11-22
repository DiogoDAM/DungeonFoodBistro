using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuMamaLib.Gui
{
	public class FlowLayout : ILayout
	{
		public List<UiComponent> Components { get; set; }
		public UiComponent Parent { get; set; }

		public int Width { get; set; }
		public int Height { get; set; }
		public Vector2 Position { get; set; }

        public FlowLayout()
		{
			Components = new();
			Position = Vector2.Zero;
		}

        public FlowLayout(Vector2 pos, int w, int h)
		{
			Components = new();
			Width = w;
			Height = h;
			Position = pos;
		}

		public void AddComponent(UiComponent component)
		{

		}

		public void RemoveComponent(UiComponent component)
		{
		}

		public void AddParent(UiComponent parent)
		{
		}

		public void RemoveParent(UiComponent parent)
		{
		}
	}
}
