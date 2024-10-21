using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;

    [SerializeField] private float _spawnTime;
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private ScoreCounter _scoreCounter;
    private bool _isWorking = false;
    private float _timer;

    public void TurnOn()
    {
        _isWorking = true;
        _timer = 0;
    }

    public void TurnOff()
    {
        _isWorking = false; 
    }

    private void Update()
    {
        if (_isWorking)
            _timer += Time.deltaTime;

        if(_timer > _spawnTime)
        {
            _timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        int emptySpawnPoint = Random.Range(0, _spawnPoints.Count);

        for (int i = 0; i < _spawnPoints.Count; i++) 
        { 
            if(i != emptySpawnPoint)
            {
                Enemy spawnedEnemy = _pool.Get();

                spawnedEnemy.transform.position = _spawnPoints[i].position;

                spawnedEnemy.Die += _scoreCounter.OnEnemyDie;
                spawnedEnemy.Despawn += _scoreCounter.OnEnemyDespawn;

            }
        }
    }
}
