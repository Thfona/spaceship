using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spaceship.Input;

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

    private readonly Ship playerShip = new(new Vector2(100, 100));

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
        InputHandler inputHandler = new();

        inputHandler.HandleInput(InputActions.ExitGame, Exit);

        playerShip.Update(gameTime, inputHandler);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(shipSprite, playerShip.Position, Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
