using UnityEngine;

public class TargetWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private float _speed;

    private Transform[] _waypoints;
    private Transform _target;
    private int _currentPoint;

    private void Start()
    {
        _waypoints = new Transform[_route.childCount];

        for (int i = 0; i < _route.childCount; i++)        
            _waypoints[i] = _route.GetChild(i);        

        _target = _waypoints[_currentPoint];
    }

    private void Update()
    {
        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _waypoints.Length)
                _currentPoint = 0;

            _target = _waypoints[_currentPoint];
        }
        else
        {
            Move(_target);
        }
    }

    private void Move(Transform target)
    {
        transform.position = Vector2.MoveTowards
            (transform.position, target.position, _speed * Time.deltaTime);
    }
}