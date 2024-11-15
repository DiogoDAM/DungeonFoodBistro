using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Gui
{
	public class UiLabel : UiComponent
	{
		public SpriteText Text;
		public new int Width { get => (int)Text.TextSize.X; }
		public new int Height { get => (int)Text.TextSize.Y; }

		public UiLabel() : base()
		{
			Text = null; 
		}

		public UiLabel(SpriteText text) : base()
		{
			Text = text;
		}

		public UiLabel(SpriteFont font, int fontSize, string text) : base()
		{
			Text = new(font, fontSize, text, Vector2.Zero);
		}

		public void SetHalignCenter()
		{
			Offset = -(Text.TextSize/2);
		}

		public void SetHalignRight()
		{
			Offset = Vector2.Zero;
		}

		public void SetHalignLeft()
		{
			Offset = Text.TextSize;
		}

		public override void Draw()
		{
			Vector2 parentPos = Vector2.Zero;
			if(_parent != null) parentPos = _parent.Transform.Position;

			Globals.SpriteBatch.DrawString(Text.Font, Text.Text, Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
			base.Draw();
		}
	}
}
