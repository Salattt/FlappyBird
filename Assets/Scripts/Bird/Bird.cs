using System;
using UnityEngine;

public class Bird : MonoBehaviour, IDamageable
{
    [SerializeField] private BirdMover _mover;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private BirdCollisionHandler _collisionHandler;
    private Vector3 _startPosition;

    public event Action Died;

    public Transform Transform {  get; private set; }

    private void OnEnable()
    {
        Transform = transform;
        _startPosition = transform.position;

        _collisionHandler.CollisionEntered += TakeDamage; 
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionEntered -= TakeDamage;
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
        Died?.Invoke();
    }
}
