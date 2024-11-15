using Microsoft.Xna.Framework;
using SuMamaLib.Utils;

namespace SuMamaLib.Gui
{
	public class UiSimplePanel : UiComponent
	{
		public Rectangle Bounds { get => new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }

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

		public override void Draw()
		{
			Drawer.DrawFillRectangle(Bounds, Color);

			base.Draw();
		}
	}
}
