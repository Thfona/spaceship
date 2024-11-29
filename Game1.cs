using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Spaceship.Input;

namespace Spaceship;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private static readonly int screenWidth = 1280;
    private static readonly int screenHeight = 720;

    private Texture2D shipSprite;
    private Texture2D asteroidSprite;
    private Texture2D spaceSprite;
    private SpriteFont gameFont;
    private SpriteFont timerFont;

    private readonly GameStateManager gameStateManager = new();

    private static readonly Vector2 shipStartingPosition = new(screenWidth / 2, screenHeight / 2);
    private readonly Ship playerShip = new(shipStartingPosition);

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        graphics.PreferredBackBufferWidth = screenWidth;
        graphics.PreferredBackBufferHeight = screenHeight;
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

        inputHandler.HandleInput(InputActions.StartGame, gameStateManager.StartGame);
        inputHandler.HandleInput(InputActions.ExitGame, Exit);

        gameStateManager.Update(gameTime);

        if (gameStateManager.IsInGame)
        {
            playerShip.Update(gameTime, inputHandler);

            for (int i = 0; i < gameStateManager.Asteroids.Count; i++)
            {
                Asteroid asteroid = gameStateManager.Asteroids[i];

                asteroid.Update(gameTime);

                int radiusesSum = asteroid.radius + playerShip.radius;
                float distance = Vector2.Distance(asteroid.Position, playerShip.Position);

                if (distance < radiusesSum)
                {
                    gameStateManager.EndGame();
                    playerShip.Position = shipStartingPosition;
                }
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(spaceSprite, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(shipSprite, playerShip.Position, Color.White);

        foreach (Asteroid asteroid in gameStateManager.Asteroids)
        {
            spriteBatch.Draw(asteroidSprite, asteroid.Position, Color.White);
        }

        if (!gameStateManager.IsInGame)
        {
            string menuMessage = "Press [Enter] or (A) to begin.";
            Vector2 textSize = gameFont.MeasureString(menuMessage);

            spriteBatch.DrawString(gameFont, menuMessage, new Vector2((screenWidth / 2) - (textSize.X / 2), 100), Color.White);
        }

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
