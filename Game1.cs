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

    private readonly GameStateManager gameStateManager = new();
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

        gameStateManager.Update(gameTime);
        playerShip.Update(gameTime, inputHandler);

        foreach (Asteroid asteroid in gameStateManager.asteroids)
        {
            asteroid.Update(gameTime);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(shipSprite, playerShip.Position, Color.White);

        foreach (Asteroid asteroid in gameStateManager.asteroids)
        {
            spriteBatch.Draw(asteroidSprite, asteroid.Position, Color.White);
        }

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
