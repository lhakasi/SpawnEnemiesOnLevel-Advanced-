using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundChecker : MonoBehaviour
{
    private const string Ground = nameof(Ground);

    private Collider2D _collider;

    public bool IsGrounded { get; private set; }

    private void Awake() =>    
        _collider = GetComponent<Collider2D>();    

    private void Update() =>    
        IsGrounded = _collider.IsTouchingLayers(LayerMask.GetMask(Ground));    
}