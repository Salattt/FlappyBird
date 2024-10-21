using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnCollision(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage();
    }
}
