using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private DestinationPoint _destinationPoint;

    public Enemy EnemyTemplate => 
        _enemyTemplate;
    public DestinationPoint DestinationPoint => 
        _destinationPoint;
}