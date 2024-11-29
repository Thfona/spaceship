using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Spaceship;

public class GameStateManager
{
    private static readonly double asteroidSpawnInitialTimeInterval = 2;
    private static readonly int asteroidInitialSpeed = 240;
    private double _playTime = 0;
    private double asteroidSpawnTimer = asteroidSpawnInitialTimeInterval;
    private double asteroidSpawnTimeInterval = asteroidSpawnInitialTimeInterval;
    private int asteroidNextSpeed = asteroidInitialSpeed;
    private bool _isInGame = false;
    private readonly List<Asteroid> _asteroids = [];

    public double PlayTime
    {
        get => Math.Floor(_playTime);
    }

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
        _playTime = 0;
        _isInGame = true;
    }

    public void EndGame()
    {
        _isInGame = false;
        _asteroids.Clear();
        asteroidSpawnTimer = asteroidSpawnInitialTimeInterval;
        asteroidSpawnTimeInterval = asteroidSpawnInitialTimeInterval;
        asteroidNextSpeed = asteroidInitialSpeed;
    }

    public void Update(GameTime gameTime)
    {
        if (_isInGame)
        {
            asteroidSpawnTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            _playTime += gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (asteroidSpawnTimer <= 0)
        {
            _asteroids.Add(new Asteroid(asteroidNextSpeed));

            asteroidSpawnTimer = asteroidSpawnTimeInterval;

            if (asteroidSpawnTimeInterval > 0.5)
            {
                asteroidSpawnTimeInterval -= 0.1;
            }

            if (asteroidNextSpeed < 720)
            {
                asteroidNextSpeed += 4;
            }
        }
    }
}
