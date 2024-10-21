using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Controller _controller;
    [SerializeField] private float _bulletSpeed;

    private void OnEnable()
    {
        _controller.Attack += Shoot;
    }

    public void GetPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
    }

    private void Shoot()
    {
        GameObject bullet = _bulletPool.Get().gameObject; 

        bullet.transform.position = _shootPoint.position;
        bullet.GetComponent<Rigidbody2D>().velocity = _shootPoint.right * _bulletSpeed;
    }
}
