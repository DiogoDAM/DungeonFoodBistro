using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions;
using SuMamaLib.Inputs;

namespace MyGame
{
	public class MainGame : Scene
	{
		private MovableCollisor box1;
		private CollisionWorld world;

		public MainGame() : base()
		{
			world = new(new Rectangle(0, 0, 1000, 1000));

			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			box1 = new MovableCollisor(new Vector2(300, 300), 50, 50);
			box1.IsSolid = true;

			Random random = new Random();
			for(int i=0; i<15; i++)
			{
				var c = new MovableCollisor(new Vector2(random.Next(0, 800)-20, random.Next(0, 600)-20), 30, 30);
				world.Add(c);
			}

			world.Add(box1);

		}

		public override void Update()
		{
			base.Update();

			if(Input.Keyboard.KeyIsPressed(Keys.D)) box1.Velocity.X = 200;
			else if(Input.Keyboard.KeyIsPressed(Keys.A)) box1.Velocity.X = -200;
			if(Input.Keyboard.KeyIsPressed(Keys.S)) box1.Velocity.Y = 200;
			else if(Input.Keyboard.KeyIsPressed(Keys.W)) box1.Velocity.Y = -200;

			world.Update();
		}

		public override void Draw()
		{
			base.Draw();

			world.Draw();
		}
	}
}
