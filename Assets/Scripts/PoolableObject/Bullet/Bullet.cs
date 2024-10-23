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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            OnCollision(collision);
        }

        _rigidbody.velocity = Vector3.zero;

        InvokeRelease();
    }

    public override void OnReset()
    {
        InvokeRelease();
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
    }

    protected virtual void OnCollision(Collider2D collision) 
    {
        
    }
}
