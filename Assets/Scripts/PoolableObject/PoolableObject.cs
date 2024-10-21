using System;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
    public event Action<PoolableObject> Release;

    public Transform Transform {  get; private set; }

    protected virtual void Awake()
    {
        Transform = transform;
    }

    public abstract void OnReset();

    protected void InvokeRelease()
    {
        Release?.Invoke((PoolableObject)this);
    }
}
