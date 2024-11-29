using Microsoft.Xna.Framework;
using Spaceship.Input;

namespace Spaceship;

public class Ship(Vector2 startingPosition, int maxAllowedHorizontalSpace, int maxAllowedVerticalSpace)
{
    private static readonly int horizontalRadius = 34;
    private static readonly int verticalRadius = 50;
    private static readonly int offset = 10;
    private readonly int horizontalOffset = horizontalRadius + offset;
    private readonly int verticalOffset = verticalRadius + offset;
    private readonly int speed = 180;
    private float deltaTime;
    private Vector2 _position = startingPosition;
    public readonly int collisionRadius = 30;

    public Vector2 Position
    {
        get => new(_position.X - horizontalRadius, _position.Y - verticalRadius);
        set => _position = value;
    }

    private void MoveUp()
    {
        if (_position.Y > verticalOffset)
        {
            _position.Y -= speed * deltaTime;
        }
    }

    private void MoveDown()
    {
        if (_position.Y < maxAllowedVerticalSpace - verticalOffset)
        {
            _position.Y += speed * deltaTime;
        }
    }

    private void MoveLeft()
    {
        if (_position.X > horizontalOffset)
        {
            _position.X -= speed * deltaTime;
        }
    }

    private void MoveRight()
    {
        if (_position.X < maxAllowedHorizontalSpace - horizontalOffset)
        {
            _position.X += speed * deltaTime;
        }
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
