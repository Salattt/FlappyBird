using UnityEngine;

public class EnemyFactory : PoolableFactory<Enemy>
{
    [SerializeField] private BulletPool _bulletPool;

    protected override void OnSpawn(Enemy poolableObject)
    {
        poolableObject.GetBulletPool(_bulletPool);
    }
}
