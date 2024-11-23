using System;
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
		public int ComponentWidth { get; set; }
		public int ComponentHeight { get; set; }
		public Vector2 Offset { get; set; }
		public Vector2 Gap { get; set; }
		public EFlowDirection Direction { get; set; } = EFlowDirection.Horizontal;

        public FlowLayout()
		{
			Components = new();
		}

        public FlowLayout(Vector2 offset, int w, int h)
		{
			Components = new();
			Width = w;
			Height = h;
			Offset = offset;
		}

        public FlowLayout(Vector2 offset, int w, int h, int cw, int ch)
		{
			Components = new();
			Width = w;
			Height = h;
			ComponentWidth = cw;
			ComponentHeight = ch;
			Offset = offset;
		}

		public void SetComponentsSize(int w, int h)
		{
			ComponentWidth = w;
			ComponentHeight = h;
		}

		public void AddListOfComponents(List<UiComponent> otherComponents)
		{
			if(otherComponents == null) { throw new NullReferenceException(); }

			Components = otherComponents;
			OrganizeAllComponents();
		}

		public void ClearComponents()
		{
			Components.Clear();
		}

		public void AddComponent(UiComponent component)
		{
			if(component == null) throw new NullReferenceException();

			Components.Add(component);
			OrganizeAllComponents();
		}

		public void RemoveComponent(UiComponent component)
		{
			if(component == null) return;

			Components.Remove(component);
			OrganizeAllComponents();
		}

		public void OrganizeAllComponents()
		{
			int breakLineCount = 0;
			int itemsLineCount = 0;
			foreach(var component in Components)
			{
				Vector2 pos = Vector2.Zero;
				if(Direction == EFlowDirection.Horizontal)
				{
					pos.X = Offset.X + (Gap.X * (itemsLineCount+1)) + (ComponentWidth * itemsLineCount);
					itemsLineCount++;
					if(pos.X + ComponentWidth > Parent.Position.X + Width)
					{
						itemsLineCount = 0;
						breakLineCount++;
						
						pos.X = + Offset.X + (Gap.X * (itemsLineCount+1)) + (ComponentWidth * itemsLineCount);
						itemsLineCount++;
					}
					pos.Y = Offset.Y + (Gap.Y * (breakLineCount+1)) + (ComponentHeight * breakLineCount);
				}
				else if(Direction == EFlowDirection.Vertical)
				{
					pos.Y = Offset.Y + (Gap.Y * (itemsLineCount+1)) + (ComponentHeight * itemsLineCount);
					itemsLineCount++;
					if(pos.Y + ComponentHeight > Parent.Position.Y + Height)
					{
						itemsLineCount = 0;
						breakLineCount++;
						
						pos.Y = Offset.Y + (Gap.Y * (itemsLineCount+1)) + (ComponentHeight * itemsLineCount);
						itemsLineCount++;
					}
					pos.X = Offset.X + (Gap.X * (breakLineCount+1)) + (ComponentWidth * breakLineCount);
				}

				component.Transform.Position = pos;
			}
		}
	}
}
