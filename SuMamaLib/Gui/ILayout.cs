using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuMamaLib.Gui
{
	public interface ILayout
	{
		public List<UiComponent> Components { get; set; }
		public UiComponent Parent { get; set; }

		public Vector2 Offset { get; set; }

		public void AddListOfComponents(List<UiComponent> components);
		public void AddComponent(UiComponent component);
		public void RemoveComponent(UiComponent component);
	}
}
