using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Controller _controller;
    [SerializeField] private float _bulletSpeed;

    private void OnEnable()
    {
        _controller.AttackInvoked += Shoot;
    }

    public void GetPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private void Shoot()
    {
        Bullet bullet = _bulletPool.Get(); 

        bullet.Transform.position = _shootPoint.position;
        bullet.SetVelocity(_shootPoint.right * _bulletSpeed);
    }
}
