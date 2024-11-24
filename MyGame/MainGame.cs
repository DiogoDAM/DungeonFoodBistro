using System;
using Microsoft.Xna.Framework;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions;

namespace MyGame
{
	public class MainGame : Scene
	{
		private Player _player;

		public MainGame() : base()
		{
			_world = new(new Rectangle(0, 0, 1000, 1000), new Vector2(0, 200));

			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			_player = new();

			AddObject(_player);
		}

		public override void Update()
		{
			base.Update();

			_world.Update();

		}

		public override void Draw()
		{
			base.Draw();


			_world.Draw();
		}
	}
}
