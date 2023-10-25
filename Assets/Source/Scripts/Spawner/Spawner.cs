using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    [SerializeField] private float _delay;
    [SerializeField] private Transform[] _spawnPoints;

    private Point _point;    
    
    private bool _isSpawning = true;

    private void Start() =>    
        StartCoroutine(SpawningEnemies());            

    private IEnumerator SpawningEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        while (_isSpawning)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            _point = spawnPoint.GetComponent<Point>();

            GameObject enemy = Instantiate(_point.EnemyTemplate.gameObject, spawnPoint.position, Quaternion.identity);

            enemy.GetComponent<EnemyMovement>().SetTarget(_point.DestinationPoint);

            yield return delay;
        }
    }
}