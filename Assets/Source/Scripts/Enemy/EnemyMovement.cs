using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private DestinationPoint _target;
    private Rigidbody2D _rigidbody2D;

    private bool _isReached;

    private void Awake() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        if (_isReached == false)
        {
            SetDirection();
            Move();
        }
        else
        {
            Stop();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DestinationPoint destination))
        {
            if (_target == destination)
            {
                _isReached = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DestinationPoint destination))
        {
            if (_target == destination)
            {
                _isReached = false;
            }
        }
    }
    public void SetTarget(DestinationPoint destination) =>
        _target = destination;

    private void SetDirection() =>
        _direction = (_target.transform.position - transform.position).normalized;

    private void Move() =>
        _rigidbody2D.velocity = _direction * _speed * Time.deltaTime;

    private void Stop() =>
        _rigidbody2D.velocity = Vector2.zero;
}