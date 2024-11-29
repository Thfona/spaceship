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
    private bool _isInGame = false;
    private readonly List<Asteroid> _asteroids = [];

    public bool IsInGame
    {
        get => _isInGame;
    }

    public List<Asteroid> Asteroids
    {
        get => _asteroids;
    }

    public void StartGame()
    {
        _isInGame = true;
    }

    public void EndGame()
    {
        _isInGame = false;
        _asteroids.Clear();
    }

    public void Update(GameTime gameTime)
    {
        if (_isInGame)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (timer <= 0)
        {
            _asteroids.Add(new Asteroid(nextSpeed));

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
