using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SuMamaLib.Gui
{
	public sealed class FlowBagLayout : ILayout
	{
		public List<UiComponent> Components { get; set; }
		public UiComponent Parent { get; set; }

		public int HorizontalLimit;
		public int VerticalLimit;
		public int ComponentWidth;
		public int ComponentHeight;
		public Vector2 Offset { get; set; }
		public Vector2 Gap { get; set; }
		public EFlowDirection Direction { get; set; } = EFlowDirection.Horizontal;

        public FlowBagLayout()
		{
			Components = new();
		}

        public FlowBagLayout(Vector2 offset, int hl, int vl)
		{
			Components = new();
			Offset = offset;
			HorizontalLimit = hl;
			VerticalLimit = vl;
		}

        public FlowBagLayout(Vector2 offset, int hl, int vl, int cw, int ch)
		{
			Components = new();
			Offset = offset;
			HorizontalLimit = hl;
			VerticalLimit = vl;
			ComponentWidth = cw;
			ComponentHeight = ch;
		}

		public void SetLimits(int h, int v)
		{
			HorizontalLimit = h;
			VerticalLimit = v;
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
					Console.WriteLine(itemsLineCount);
					if(itemsLineCount > HorizontalLimit)
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
					if(itemsLineCount > VerticalLimit)
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
