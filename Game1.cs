using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private Texture2D shipSprite;
    private Texture2D asteroidSprite;
    private Texture2D spaceSprite;
    private SpriteFont gameFont;
    private SpriteFont timerFont;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = 1280;
        graphics.PreferredBackBufferHeight = 720;
        graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        shipSprite = Content.Load<Texture2D>("ship");
        asteroidSprite = Content.Load<Texture2D>("asteroid");
        spaceSprite = Content.Load<Texture2D>("space");

        gameFont = Content.Load<SpriteFont>("spaceFont");
        timerFont = Content.Load<SpriteFont>("timerFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
