using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuMamaLib.Behaviours;
using SuMamaLib.Collisions;
using SuMamaLib.Inputs;
using SuMamaLib.Utils;
using SuMamaLib.Utils.Sprites;

namespace MyGame
{
    public class Player : GameObject
    {
		private Vector2 _speed;
		private MovableCollisor col;

        public Player() : base()
        {
			Transform.Position = new Vector2(100, 100);
			Transform.Scale = new Vector2(2,2);
			_speed = new Vector2(500,500);
			Sprite = new Sprite(Globals.Content.Load<Texture2D>("Sprites/characterForTest"), new Point(0,0), new Point(32, 32));

			col = new(Transform, 32, 48);
        }

		public override void Start()
		{
			SceneManager.AddCollisor(col);
		}

		public override void Update()
		{
			Vector2 dir = Vector2.Zero;

			if(Input.Keyboard.KeyIsPressed(Keys.D)){ dir += new Vector2(1,0); }
			if(Input.Keyboard.KeyIsPressed(Keys.A)){ dir += new Vector2(-1,0); }
			if(Input.Keyboard.KeyIsPressed(Keys.S)){ dir += new Vector2(0,1); }
			if(Input.Keyboard.KeyIsPressed(Keys.W)){ dir += new Vector2(0, -1); }

			if(dir != Vector2.Zero)
			{
				dir = Vector2.Normalize(dir);
			}

			Transform.Translate(dir * _speed * new Vector2(Globals.DeltaTime, Globals.DeltaTime));
		}
    }
}
