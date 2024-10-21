using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnCollision(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bird bird))
            bird.TakeDamage();
    }
}
