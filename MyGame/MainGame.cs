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
		private RigidBody _body1, _body2;

		public MainGame() : base()
		{
			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			_rect1 = new(new Vector2(300, 100), 30, 30);
			_rect2 = new(new Vector2(400, 100), 30, 30);

			_body1 = new(_rect1);
			_body1.Friction = 1f;
			_body2 = new(_rect2);
		}

		public override void Update()
		{
			base.Update();

			if(Input.Keyboard.KeyIsPressed(Keys.D)){ _body1.ApplyForce(new Vector2(200, 0)); }
			else if(Input.Keyboard.KeyIsPressed(Keys.A)){ _body1.ApplyForce(new Vector2(-200, 0)); }
			if(Input.Keyboard.KeyIsPressed(Keys.S)){ _body1.ApplyForce(new Vector2(0, 200)); }
			else if(Input.Keyboard.KeyIsPressed(Keys.W)){ _body1.ApplyForce(new Vector2(0, -200)); }

			_body1.Update();
			_body2.Update();

			System.Console.WriteLine($"Vel {_body1.Velocity}");
		}

		public override void Draw()
		{
			base.Draw();

			Drawer.DrawFillRectangle(_rect1.BoundingRectangle, Color.Red);
			Drawer.DrawFillRectangle(_rect2.BoundingRectangle, Color.Blue);
		}

	}
}
