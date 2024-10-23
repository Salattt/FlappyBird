using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class BirdCollisionHandler : MonoBehaviour
{
    private CircleCollider2D _circleCollider;

    public event Action CollisionEntered;

    private void Awake()
    {
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IInteractable>(out _))
            CollisionEntered?.Invoke();
    }
}
