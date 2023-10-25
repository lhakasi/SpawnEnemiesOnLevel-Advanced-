using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    [SerializeField] private float _delay;
    [SerializeField] private Point[] _spawnPoints;      
    
    private bool _isSpawning = true;

    private void Start() =>    
        StartCoroutine(SpawningEnemies());            

    private IEnumerator SpawningEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (_isSpawning)
        {
            Point spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            Enemy enemy = Instantiate(spawnPoint.EnemyTemplate, spawnPoint.transform.position, Quaternion.identity);

            enemy.GetComponent<EnemyMovement>().SetTarget(spawnPoint.DestinationPoint);

            yield return delay;
        }
    }
}