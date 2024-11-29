using System;
using Microsoft.Xna.Framework;

namespace Spaceship;

public class Asteroid
{
    private readonly int speed;
    private Vector2 _position;
    public readonly int radius = 59;

    public Asteroid(int speed)
    {
        this.speed = speed;

        Random random = new();
        _position = new(1380, random.Next(radius + 10, 711 - radius));
    }

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
