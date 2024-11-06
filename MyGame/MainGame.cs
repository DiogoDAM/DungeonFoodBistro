using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions;
using SuMamaLib.Collisions.Interfaces;
using SuMamaLib.Inputs;
using SuMamaLib.Utils;

namespace MyGame
{
	public class MainGame : Scene
	{
		private BoxCollisor _rect1, _rect2;
		private CircleCollisor _circle;
		private RigidBody _body1, _body2;

		private CollisionWorld _world;

		public MainGame() : base()
		{
			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			_rect1 = new BoxCollisor(new Vector2(300, 300), 50, 50);
			_rect2 = new BoxCollisor(new Vector2(400, 300), 50, 50);
			_circle = new CircleCollisor(new Vector2(400, 300), 50);

			_body1 = new(_rect1);
			_body2 = new(_rect2);

			_body1.CollisionEnter += OnCollisionEnter;
			_body1.CollisionStay += OnCollisionStay;
			_body1.CollisionExit += OnCollisionExit;

			_world = new(new Rectangle(0, 0, 1200, 1200));
			_world.AddBody(_body1);
			_world.AddBody(_body2);
		}

		public override void Update()
		{
			base.Update();

			if(Input.Keyboard.KeyIsPressed(Keys.D)){ _body1.Velocity += new Vector2(200, 0); }
			else if(Input.Keyboard.KeyIsPressed(Keys.A)){ _body1.Velocity += new Vector2(-200, 0); }
			if(Input.Keyboard.KeyIsPressed(Keys.S)){ _body1.Velocity += new Vector2(0, 200); }
			else if(Input.Keyboard.KeyIsPressed(Keys.W)){ _body1.Velocity += new Vector2(0, -200); }

			_world.Update();
		}

		public override void Draw()
		{
			base.Draw();

			Drawer.DrawFillRectangle(_rect1.BoundingRectangle, Color.Red);
			Drawer.DrawFillRectangle(_rect2.BoundingRectangle, Color.Blue);
			Drawer.DrawFillRectangle(_rect1.GetIntersection(_rect2), Color.Purple);

		}

		public void OnCollisionEnter(CollisionEventArgs other)
		{
			System.Console.WriteLine("Enter");
		}

		public void OnCollisionStay(CollisionEventArgs other)
		{
			System.Console.WriteLine("Stay");
		}

		public void OnCollisionExit(CollisionEventArgs other)
		{
			System.Console.WriteLine("Exit");
		}
	}
}
