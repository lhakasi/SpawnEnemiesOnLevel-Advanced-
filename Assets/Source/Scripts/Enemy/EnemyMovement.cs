using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private Transform _target;
    private Rigidbody2D _rigidbody2D;

    private void Awake() =>    
        _rigidbody2D = GetComponent<Rigidbody2D>();    

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        if (_target.position != transform.position)
        {
            SetDirection();
            Move();
        }
        else
        {
            Stop();
        }        
    }

    public void SetTarget(DestinationPoint destination) =>
        _target = destination.Position;

    private void SetDirection() =>
        _direction = (_target.position - transform.position).normalized;

    private void Move() =>
        _rigidbody2D.velocity = _direction * _speed;

    private void Stop() =>
        _rigidbody2D.velocity = Vector2.zero;
}