using Microsoft.Xna.Framework;
using System;
using SuMamaLib.Utils;

namespace SuMamaLib.Gui
{
	public class UiSimplePanel : UiComponent
	{
		public Rectangle Bounds { get => new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }

		public ILayout Layout;

		public UiSimplePanel() : base()
		{
		}

		public UiSimplePanel(Rectangle bounds, Color color) : base()
		{
			Transform.Position = bounds.Location.ToVector2();
			Width = bounds.Width;
			Height = bounds.Height;
			Color = color;
		}

		public UiSimplePanel(Vector2 pos, int w, int h, Color color) : base()
		{
			Transform.Position = pos;
			Width = w;
			Height = h;
			Color = color;
		}

		public UiSimplePanel(int w, int h, Color color) : base()
		{
			Width = w;
			Height = h;
			Color = color;
		}

		public void SetLayout(ILayout layout)
		{
			if(layout == null) throw new NullReferenceException();

			Layout = layout;
			Layout.Parent = this;
			Layout.AddListOfComponents(_children);
		}

		public new void AddChild(UiComponent component)
		{
			if(component == null) throw new NullReferenceException();

			if(Layout != null)
			{
				Layout.AddComponent(component);
			}
			else
			{
				_children.Add(component);
			}
		}

		public new void RemoveChild(UiComponent component)
		{
			if(component == null) return;

			if(Layout != null)
			{
				Layout.RemoveComponent(component);
			}
			else
			{
				_children.Add(component);
			}
		}

		public override void Draw()
		{
			Drawer.DrawFillRectangle(Bounds, Color);

			base.Draw();
		}
	}
}
