using UnityEngine;

public class DestinationPoint : MonoBehaviour
{
    private Transform _transform;

    public Transform Position =>
        _transform;

    private void Awake() =>
        _transform = GetComponent<Transform>();
}