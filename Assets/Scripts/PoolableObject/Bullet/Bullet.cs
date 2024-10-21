using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : PoolableObject
{
    private Rigidbody2D _rigidbody;

    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void OnReset()
    {
        InvokeRelease();
    }

    protected virtual void OnCollision(Collider2D collision) 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            OnCollision(collision);
        }

        _rigidbody.velocity = Vector3.zero;

        InvokeRelease();
    }
}
