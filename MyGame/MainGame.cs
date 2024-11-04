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
		private CircleCollisor _rect1, _rect2;

		public MainGame() : base()
		{
			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			_rect1 = new(new Vector2(200, 200), 50);
			_rect2 = new(new Vector2(300, 200), 50);

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

			if(_rect1.Intersects(_rect2))
			{
				System.Console.WriteLine("The Circles Intersects");
			}

		}

		public override void Draw()
		{
			base.Draw();
		}

	}
}
