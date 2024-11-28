using Microsoft.Xna.Framework;
using Spaceship.Input;

namespace Spaceship;

public class Ship(Vector2 startingPosition)
{
    private readonly int speed = 180;
    private float deltaTime;
    private Vector2 _position = startingPosition;

    public Vector2 Position
    {
        get => new(_position.X - 34, _position.Y - 50);
    }

    private void MoveUp()
    {
        _position.Y -= speed * deltaTime;
    }

    private void MoveDown()
    {
        _position.Y += speed * deltaTime;
    }

    private void MoveLeft()
    {
        _position.X -= speed * deltaTime;
    }

    private void MoveRight()
    {
        _position.X += speed * deltaTime;
    }

    public void Update(GameTime gameTime, InputHandler inputHandler)
    {
        deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        inputHandler.HandleInput(InputActions.MoveUp, MoveUp);
        inputHandler.HandleInput(InputActions.MoveDown, MoveDown);
        inputHandler.HandleInput(InputActions.MoveLeft, MoveLeft);
        inputHandler.HandleInput(InputActions.MoveRight, MoveRight);
    }
}
