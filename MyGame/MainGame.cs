using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions;
using SuMamaLib.Inputs;
using SuMamaLib.Utils;

namespace MyGame
{
	public class MainGame : Scene
	{
		private Rectangle _rect1, _rect2;

		public MainGame() : base()
		{
			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			_rect1 = new Rectangle(300, 300, 50, 50);
			_rect2 = new Rectangle(400, 300, 50, 50);

		}

		public override void Update()
		{
			base.Update();

			if(Input.Keyboard.KeyIsPressed(Keys.D)) _rect1.X += 10;
			else if(Input.Keyboard.KeyIsPressed(Keys.A)) _rect1.X -= 10;
			if(Input.Keyboard.KeyIsPressed(Keys.S)) _rect1.Y += 10;
			else if(Input.Keyboard.KeyIsPressed(Keys.W)) _rect1.Y -= 10;

			if(_rect1.Intersects(_rect2))
			{
				Rectangle intersectionRect = Rectangle.Intersect(_rect1, _rect2);

				if(intersectionRect.Width < intersectionRect.Height)
				{
					if(_rect1.X < _rect2.X)
					{
						_rect1.X -= intersectionRect.Width;
					}
					else
					{
					    _rect1.X += intersectionRect.Width;
					}
				}
				else
				{
					if(_rect1.Y < _rect2.Y)
					{
						_rect1.Y -= intersectionRect.Height;
					}
					else
					{
					    _rect1.Y += intersectionRect.Height;
					}
				}
			}
		}

		public override void Draw()
		{
			base.Draw();

			Drawer.DrawFillRectangle(_rect1, Color.Red);
			Drawer.DrawFillRectangle(_rect2, Color.Blue);
		}

	}
}
