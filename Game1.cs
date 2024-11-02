using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGame;
using SuMamaLib.Behaviours;
using SuMamaLib.Inputs;
using SuMamaLib.Utils;

namespace DungeonFoodBistro;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
	private MainGame _mainGame;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
		base.LoadContent();
		Globals.Initialize(GraphicsDevice, Content);

		Globals.Content.Load<Texture2D>("Sprites/Ana");

		_mainGame = new();

		SceneManager.AddScene(_mainGame);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        // TODO: Add your update logic here

		Globals.Update(gameTime);
		Input.Update();

		SceneManager.Update(); 
		base.Update(gameTime); 
	} 
	protected override void Draw(GameTime gameTime) 
	{ 
		GraphicsDevice.Clear(Color.CornflowerBlue);
		Globals.SpriteBatch.Begin();

		SceneManager.Draw();

		Globals.SpriteBatch.End();

		base.Draw(gameTime);

    }
}
