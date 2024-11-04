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
		private RectangleCollisor _rect1, _rect2;

		public MainGame() : base()
		{
			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			_rect1 = new(new Vector2(200, 200), 50, 50);
			_rect2 = new(new Vector2(300, 200), 50, 50);

		}

		public override void Update()
		{
			base.Update();

			if(Input.Keyboard.KeyIsPressed(Keys.D))
			{
				_rect1.Transform.Translate(new Vector2(10, 0));
			}
			else if(Input.Keyboard.KeyIsPressed(Keys.A))
			{
				_rect1.Transform.Translate(new Vector2(-10, 0));
			}

		}

		public override void Draw()
		{
			base.Draw();

			Drawer.DrawFillRectangle(_rect1.Transform.Position, _rect1.Width, _rect1.Height, Color.Red);
			Drawer.DrawFillRectangle(_rect2.Transform.Position, _rect2.Width, _rect2.Height, Color.Blue);
			var test = _rect1.GetIntersection(_rect2);
			Drawer.DrawFillRectangle(new Vector2(test.X, test.Y), test.Width, test.Height, Color.White);
		}

	}
}
