using Microsoft.Xna.Framework;

namespace Spaceship;

public class Asteroid(int speed)
{
    private readonly int speed = speed;
    private readonly int radius = 59;
    private Vector2 _position = new(600, 300);

    public Vector2 Position
    {
        get => new(_position.X - radius, _position.Y - radius);
    }

    public void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        _position.X -= speed * deltaTime;
    }
}
