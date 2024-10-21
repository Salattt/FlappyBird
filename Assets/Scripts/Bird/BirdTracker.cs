using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffset;
    private Transform _transform;

    private void OnEnable()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = new Vector3(_bird.Transform.position.x + _xOffset, _transform.position.y, _transform.position.z);
    }
}
