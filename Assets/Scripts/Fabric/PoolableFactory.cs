using UnityEngine;

public class PoolableFactory<T> : MonoBehaviour where T : PoolableObject
{
    [SerializeField] private T _blueprint;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public T Get()
    {
        T poolableObject = Instantiate(_blueprint, _transform);

        OnSpawn(poolableObject);

        return poolableObject;
    }

    protected virtual void OnSpawn(T poolableObject)
    {
    }
}
