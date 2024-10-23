using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Enemy : PoolableObject, IDamageable, IInteractable
{
    [SerializeField] private Shooter _shooter;

    public event Action<Enemy> Died;
    public event Action<Enemy> Despawned;

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
        Died?.Invoke(this);

        InvokeRelease();
    }

    public void InvokeDespawn()
    {
        Despawned?.Invoke(this);

        InvokeRelease();
    }
}
