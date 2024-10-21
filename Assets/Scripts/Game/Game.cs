using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private List<BulletPool> _bulletPools;

    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private Floor _floor;

    private void OnEnable()
    {
        _startScreen.Start += TurnOn;
        _bird.Die += TurnOff;
        _endScreen.Restart += ResetGame;
        _endScreen.Restart += TurnOn;

        _startScreen.Open();
    }

    private void OnDisable()
    {
        _startScreen.Start -= TurnOn;
        _bird.Die -= TurnOff;
        _endScreen.Restart -= ResetGame;
        _endScreen.Restart -= TurnOn;
    }

    private void TurnOn()
    {
        _bird.TurnOn();
        _enemySpawner.TurnOn();
        _floor.TurnOn();
    }

    private void ResetGame()
    {
        foreach(BulletPool bulletPool in _bulletPools)
            bulletPool.ResetComponent();

        _bird.ResetComponent();
        _enemyPool.ResetComponent();
        _scoreCounter.ResetComponent();
    }

    private void TurnOff()
    {
        _bird.TurnOff();
        _enemySpawner.TurnOff();
        _floor.TurnOff();

        _endScreen.Open();
    }
}