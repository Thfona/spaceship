using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Spaceship;

public class GameStateManager
{
    private static readonly double initialTime = 2;
    private double timer = initialTime;
    private double maxTime = initialTime;
    private int nextSpeed = 240;
    public List<Asteroid> asteroids = [];

    public void Update(GameTime gameTime)
    {
        timer -= gameTime.ElapsedGameTime.TotalSeconds;

        if (timer <= 0)
        {
            asteroids.Add(new Asteroid(nextSpeed));

            timer = maxTime;

            if (maxTime > 0.5)
            {
                maxTime -= 0.1;
            }

            if (nextSpeed < 720)
            {
                nextSpeed += 4;
            }
        }
    }
}
