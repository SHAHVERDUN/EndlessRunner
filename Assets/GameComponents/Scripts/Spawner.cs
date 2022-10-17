using UnityEngine;

public class Spawner : GameObjectPool
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float _secondsBetweenSpawn;

    [SerializeField]
    private Transform[] _spawnPoints;

    private float _runningTime;

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        SpawnFromPrefab(CheckSpawnTime());
    }

    private bool CheckSpawnTime()
    {
        _runningTime += Time.deltaTime;

        if(_runningTime >= _secondsBetweenSpawn)
        {
            _runningTime = 0;

            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpawnFromPrefab(bool isSpawn)
    {
        if (isSpawn == true && TryGetObject(out GameObject enemy))
        {
            int randomSpawnPointNumber = Random.Range(0, _spawnPoints.Length);

            ActivateEnemy(enemy, _spawnPoints[randomSpawnPointNumber].position);
        }
    }

    private void ActivateEnemy(GameObject enemy, Vector2 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}