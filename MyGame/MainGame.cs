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
			_rect2 = new(new Vector2(300, 200), 30, 30);

			_body1 = new(_rect1);
			_body2 = new(_rect2);

			_body1.CollisionEnter += OnCollisionEnter;
			_body1.CollisionStay += OnCollisionStay;
			_body1.CollisionExit += OnCollisionExit;
		}

		public override void Update()
		{
			base.Update();

			if(Input.Keyboard.KeyIsPressed(Keys.D)){ _body1.Velocity += new Vector2(200, 0); }
			else if(Input.Keyboard.KeyIsPressed(Keys.A)){ _body1.Velocity += new Vector2(-200, 0); }
			if(Input.Keyboard.KeyIsPressed(Keys.S)){ _body1.Velocity += new Vector2(0, 200); }
			else if(Input.Keyboard.KeyIsPressed(Keys.W)){ _body1.Velocity += new Vector2(0, -200); }

			_body1.UpdateCollision(_body2.Collisor, _body1.Collisor.Intersects(_body2.Collisor));

			_body1.Update();
			_body2.Update();
		}

		public override void Draw()
		{
			base.Draw();

			Drawer.DrawFillRectangle(_rect1.BoundingRectangle, Color.Red);
			Drawer.DrawFillRectangle(_rect2.BoundingRectangle, Color.Blue);

			Drawer.DrawFillRectangle(_rect1.GetIntersection(_rect2), Color.Purple);
		}

		public void OnCollisionEnter(CollisionArgs other)
		{
			System.Console.WriteLine("Enter");
		}

		public void OnCollisionStay(CollisionArgs other)
		{
			System.Console.WriteLine("Stay");
		}

		public void OnCollisionExit(CollisionArgs other)
		{
			System.Console.WriteLine("Exit");
		}
	}
}
