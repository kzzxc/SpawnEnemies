using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _spawnInterval = 2;
    private bool _isPlaying = true;

    void Start()
    {
        StartCoroutine(spawnEnemy(_spawnInterval, _enemyPrefab, _spawnPoints));
    }

    private IEnumerator spawnEnemy(float interval, Enemy enemy, Transform[] spawnPoints)
    {
        while (_isPlaying)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                Instantiate(enemy, spawnPoint.position, Quaternion.identity);

                yield return new WaitForSeconds(interval);
            }
        }
    }
}
