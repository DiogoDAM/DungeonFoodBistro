using Microsoft.Xna.Framework.Input;
using SuMamaLib.Behaviours;
using SuMamaLib.Inputs;

namespace MyGame
{
	public class MainGame : Scene
	{
		private Player _player;

		public MainGame() : base()
		{
			_objectsList.Add(new());
			_objectsList.Add(new());
			_objectsList.Add(new());

			_player = new();
			AddObject(_player);
		}

		public override void Update()
		{
			base.Update();

			if(Input.Keyboard.KeyWasPressed(Keys.Space))
			{
				DestroyObject(_player);
			}
			if(Input.Keyboard.KeyWasPressed(Keys.Enter))
			{
				AddObject(_player);
			}
		}

	}
}
