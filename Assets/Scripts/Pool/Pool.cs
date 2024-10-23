using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : PoolableObject
{
    private List<T> _objectsInPool = new List<T>();
    private List<T> _objects = new List<T>(); 

    [SerializeField] private PoolableFactory<T> _fabric;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public T Get()
    {
        T poolableObject;

        if (_objectsInPool.Count == 0)
        {
            poolableObject =  _fabric.Get();
            _objects.Add(poolableObject);
        }
        else
        {
            poolableObject = _objectsInPool[0];   
            _objectsInPool.RemoveAt(0);
        }

        poolableObject.gameObject.SetActive(true);

        poolableObject.Released += OnRelease;

        return poolableObject;
    }

    public void ResetComponent()
    {
        foreach(T poolableObject in _objects)
        {
            if(_objectsInPool.Contains(poolableObject) == false)
                poolableObject.OnReset();
        }
    }

    private void OnRelease(PoolableObject poolableObject)
    {
        poolableObject.Released -= OnRelease;

        poolableObject.Transform.position = _transform.position;

        poolableObject.gameObject.SetActive(false);

        _objectsInPool.Add((T)poolableObject);
    }
}
