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
		private UiTexturedButton _button, _button2, _button3, _button4, _button5, _button6;
		private UiTexturedPanel _panel;

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
			_label.Transform.Position = new Vector2(10, 10);
			_label.Color = Color.White;

			_button = new UiTexturedButton(new Sprite(Globals.Content.Load<Texture2D>("Sprites/buttonTest")), 150, 80, Color.White);
			_button2 = new UiTexturedButton(new Sprite(Globals.Content.Load<Texture2D>("Sprites/buttonTest")), 150, 80, Color.White);
			_button3 = new UiTexturedButton(new Sprite(Globals.Content.Load<Texture2D>("Sprites/buttonTest")), 150, 80, Color.White);
			_button4 = new UiTexturedButton(new Sprite(Globals.Content.Load<Texture2D>("Sprites/buttonTest")), 150, 80, Color.White);
			_button5 = new UiTexturedButton(new Sprite(Globals.Content.Load<Texture2D>("Sprites/buttonTest")), 150, 80, Color.White);
			_button6 = new UiTexturedButton(new Sprite(Globals.Content.Load<Texture2D>("Sprites/buttonTest")), 150, 80, Color.White);
			_button.CursorHover += OnCursorHover;
			_button.CursorEndHover += OnCursorEndHover;
			_button.CursorClick += OnCursorClick;
			_button.CursorClicking += OnCursorClicking;
			_button.CursorEndClick += OnCursorEndClick;
			_button.AddChild(_label);

			_panel = new UiTexturedPanel(new NineSlice(Globals.Content.Load<Texture2D>("Sprites/buttonTestNineSlice"), new Rectangle(0,0, 33, 33)), new Vector2(1024-350, 0), 350, 576);
			FlowLayout layout = new FlowLayout(_panel.Position, 350, 576, 150, 80);
			layout.Gap = new Vector2(20, 30);
			_panel.SetLayout(layout);
			_panel.AddChild(_button);
			_panel.AddChild(_button2);
			_panel.AddChild(_button3);
			_panel.AddChild(_button4);
			_panel.AddChild(_button5);
			_panel.AddChild(_button6);
			_panel.SetNineSliceToRepeat(500/11, 576/11);


			_player = new();

			AddObject(_player);
		}

		public override void Update()
		{
			base.Update();

			_panel.Update();


			_world.Update();

		}

		public override void Draw()
		{
			base.Draw();

			_panel.Draw();

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
