using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuMamaLib.Gui
{
	public interface ILayout
	{
		public List<UiComponent> Components { get; set; }
		public UiComponent Parent { get; set; }

		public Vector2 Position { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public void AddComponent(UiComponent component);
		public void RemoveComponent(UiComponent component);
		public void AddParent(UiComponent parent);
		public void RemoveParent(UiComponent parent);
	}
}
