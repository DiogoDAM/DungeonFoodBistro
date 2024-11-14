using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions;
using SuMamaLib.Gui;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace MyGame
{
	public class MainGame : Scene
	{
		private Player _player;
		private UiLabel _label;

		public MainGame() : base()
		{
			_world = new(new Rectangle(0, 0, 1000, 1000), new Vector2(0, 200));

			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			Random random = new();
			for(int i=0; i<20; i++)
			{
				var col = new StaticCollisor(new Vector2(random.Next(0, 800), random.Next(0, 600)), 32, 32);
				col.Class.Classification.Add("wall");
				col.Class.Solid.Add("wall");
				AddCollisor(col);
			}

			_label = new UiLabel(Globals.Content.Load<SpriteFont>("Fonts/Alagard"), 16, "Dragon Pie");
			_label.Transform.Position = new Vector2(400, 300);
			_label.SetHalignCenter();

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

			_label.Draw();

			_world.Draw();
		}
	}
}
