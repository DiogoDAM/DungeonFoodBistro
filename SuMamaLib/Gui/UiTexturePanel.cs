using Microsoft.Xna.Framework;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Gui
{
	public class UiTexturedPanel : UiComponent
	{
		private NineSlice _sprite;

		public ENineSliceTypes NineSliceType { get; private set; }= ENineSliceTypes.None;
		public int _repetitionX, _repetitionY;
		public int _stretchX, _stretchY;

		public Rectangle Bounds { get => new Rectangle((int)Position.X, (int)Position.Y, Width, Height); }

		public UiTexturedPanel() : base()
		{
			_sprite = null;
		}

		public UiTexturedPanel(NineSlice sprite, Vector2 pos, int width, int height) : base()
		{
			_sprite = sprite;
			Transform.Position = pos;
			Width = width;
			Height = height;
		}

		public void SetNineSliceToNone()
		{
			NineSliceType = ENineSliceTypes.None;
		}

		public void SetNineSliceToRepeat(int repX, int repY)
		{
			NineSliceType = ENineSliceTypes.Repeat;
			_repetitionX = repX;
			_repetitionY = repY;
		}

		public void SetNineSliceToStretch(int sx, int sy)
		{
			NineSliceType = ENineSliceTypes.Stretch;
			_stretchX = sx;
			_stretchY = sy;
		}

		public override void Draw()
		{
			if(NineSliceType == ENineSliceTypes.None)
			{
				_sprite.DrawWithNone(Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
			}
			else if(NineSliceType == ENineSliceTypes.Repeat)
			{
				_sprite.DrawWithRepeat(_repetitionX, _repetitionY, Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
			}
			else if(NineSliceType == ENineSliceTypes.Stretch)
			{
				_sprite.DrawWithStretch(_stretchX, _stretchY, Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
			}

			base.Draw();
		}
	}
}
