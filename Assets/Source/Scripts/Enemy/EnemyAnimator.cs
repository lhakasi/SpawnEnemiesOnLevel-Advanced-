using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(GroundChecker))]
public class EnemyAnimator : MonoBehaviour
{
    private const string Speed = nameof(Speed);
    private const string Fall = nameof(Fall);
    private const string Ground = nameof(Ground);

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private GroundChecker _groundChecker;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _groundChecker = GetComponent<GroundChecker>();
    }

    private void Update()
    {
        _animator.SetBool(Fall, !_groundChecker.IsGrounded);
        _animator.SetFloat(Speed, Mathf.Abs(_rigidbody2D.velocity.x));

        FlipModel();
    }

    private void FlipModel()
    {
        if (_rigidbody2D.velocity.x > 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}