using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace MyGame
{
	public class MainGame : Scene
	{
		private Player _player;
		private SpriteText Text;

		public MainGame() : base()
		{
			_world = new(new Rectangle(0, 0, 1000, 1000), new Vector2(0, 200));

			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			Random random = new();
			for(int i=0; i<20; i++)
			{
				AddCollisor(new StaticCollisor(new Vector2(random.Next(0, 800), random.Next(0, 600)), 32, 32));
			}

			Text = new SpriteText(Globals.Content.Load<SpriteFont>("Fonts/Alagard"), 16, "Dragon Pie", new Vector2(300, 100));

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

			Globals.SpriteBatch.DrawString(Text.Font, Text.Text, Text.Position, Text.Color);

			_world.Draw();
		}
	}
}
