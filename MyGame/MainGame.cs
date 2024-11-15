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
		private UiTexturedButton _button;

		public MainGame() : base()
		{
			_world = new(new Rectangle(0, 0, 1000, 1000), new Vector2(0, 200));

			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			Random random = new();
			for(int i=0; i<20; i++)
			{
				var col = new StaticCollisor(new Vector2(random.Next(0, 1000), random.Next(0, 550)), 32, 32);
				col.Class.Classification.Add("wall");
				col.Class.Solid.Add("wall");
				AddCollisor(col);
			}

			_label = new UiLabel(Globals.Content.Load<SpriteFont>("Fonts/Alagard"), 16, "Dragon Pie");
			_label.Color = Color.White;

			_button = new UiTexturedButton(new Sprite(Globals.Content.Load<Texture2D>("Sprites/buttonTest")), 150, 80, Color.White);
			_button.AddChild(_label);
			_button.CursorHover += OnCursorHover;
			_button.CursorEndHover += OnCursorEndHover;

			_button.CursorClick += OnCursorClick;
			_button.CursorClicking += OnCursorClicking;
			_button.CursorEndClick += OnCursorEndClick;

			_player = new();

			AddObject(_player);
		}

		public override void Update()
		{
			base.Update();

			_button.Update();

			_world.Update();

		}

		public override void Draw()
		{
			base.Draw();

			_button.Draw();

			_world.Draw();
		}

		private void OnCursorHover()
		{
			_button.Color = Color.Yellow;
		}

		private void OnCursorEndHover()
		{
			_button.Color = Color.White;
		}

		private void OnCursorClick()
		{
			_button.Color = Color.Red;
		}

		private void OnCursorClicking()
		{
			_button.Color = Color.DarkRed;
		}

		private void OnCursorEndClick()
		{
			_button.Color = Color.Gray;
		}
	}
}
