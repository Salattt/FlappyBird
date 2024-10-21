using System;
using UnityEngine;

public class Bird : MonoBehaviour, IDamageable
{
    [SerializeField] private BirdMover _mover;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private BirdCollisionHandler _collisionHandler;
    private Vector3 _startPosition;

    public event Action Die;

    public Transform Transform {  get; private set; }

    private void OnEnable()
    {
        Transform = transform;
        _startPosition = transform.position;

        _collisionHandler.CollisionEnter += TakeDamage; 
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionEnter -= TakeDamage;
    }

    public void TurnOn()
    {
        _mover.TurnOn();
        _playerController.TurnOn();
    }

    public void TurnOff()
    {
        _mover.TurnOff();
        _playerController.TurnOff();   
    }

    public void ResetComponent()
    {
        Transform.position = _startPosition;
    }

    public void TakeDamage()
    {
        Die?.Invoke();
    }
}
