using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _centerOfMass;

    private Rigidbody2D _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.centerOfMass = _centerOfMass;
    }

    private void OnEnable()
    {
        _controller.JumpInvoked += OnJump;
    }

    private void OnDisable()
    {
        _controller.JumpInvoked -= OnJump;
    }

    private void Update()
    {
        UpdateRotation();
    }

    public void TurnOn()
    {
        _rigidbody.velocity = Vector2.right * _speed;
        _rigidbody.gravityScale = 1f;
    }

    public void TurnOff()
    {
        _rigidbody.velocity=Vector2.zero;
    }

    private void OnJump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse);
    }

    private void UpdateRotation()
    {
        _transform.right = _rigidbody.velocity;
    }
}
