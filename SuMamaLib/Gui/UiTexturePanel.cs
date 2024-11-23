using System;
using Microsoft.Xna.Framework;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace SuMamaLib.Gui
{
	public class UiTexturedPanel : UiComponent
	{
		private NineSlice _sprite;
		public ILayout Layout { get; set; }

		public ENineSliceTypes NineSliceType { get; private set; } = ENineSliceTypes.None;

		private int _repX = 0, _repY = 0;
		private int _streX = 0, _streY = 0;

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

		public void SetNineSliceToNone()
		{
			NineSliceType = ENineSliceTypes.None;
		}

		public void SetNineSliceToRepeat(int repX, int repY)
		{
			NineSliceType = ENineSliceTypes.Repeat;
			_repX = repX;
			_repY = repY;
		}

		public void SetNineSliceToStreatch(int strX, int strY)
		{
			NineSliceType = ENineSliceTypes.Stretch;
			_streX = strX;
			_streY = strY;
		}

		public override void Draw()
		{
			if(NineSliceType == ENineSliceTypes.None)
			{
				_sprite.DrawWithNone(Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
			}
			else if(NineSliceType == ENineSliceTypes.Repeat)
			{
				_sprite.DrawWithRepeat(_repX, _repY, Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
			}
			else if(NineSliceType == ENineSliceTypes.Stretch)
			{
				_sprite.DrawWithStretch(_streX, _streY, Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffect, Depth);
			}

			base.Draw();
		}
	}
}
