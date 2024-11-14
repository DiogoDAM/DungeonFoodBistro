using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Gui
{
	public class UiLabel : UiComponent
	{
		public SpriteText Text;

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
			Text.Position = -(Text.TextSize/2);
		}

		public void SetHalignRight()
		{
			Text.Position = Vector2.Zero;
		}

		public void SetHalignLeft()
		{
			Text.Position = Text.TextSize;
		}

		public override void Draw()
		{
			Vector2 parentPos = Vector2.Zero;
			if(_parent != null) parentPos = _parent.Transform.Position;

			Globals.SpriteBatch.DrawString(Text.Font, Text.Text, parentPos + Transform.Position + Text.Position, Text.Color, Transform.Rotation, Origin, Transform.Scale, Text.SpriteEffect, Depth);
			base.Draw();
		}
	}
}
