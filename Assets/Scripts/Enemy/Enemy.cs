using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : PoolableObject, IDamageable, IInteractable
{
    [SerializeField] private Shooter _shooter;

    public event Action<Enemy> Die;
    public event Action<Enemy> Despawn;

    public override void OnReset()
    {
        InvokeDespawn();
    }

    public void GetBulletPool(BulletPool bulletPool)
    {
        _shooter.GetPool(bulletPool);
    }

    public void TakeDamage()
    {
        Die?.Invoke(this);

        InvokeRelease();
    }

    public void InvokeDespawn()
    {
        Despawn?.Invoke(this);

        InvokeRelease();
    }
}
