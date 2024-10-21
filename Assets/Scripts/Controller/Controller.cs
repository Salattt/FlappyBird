using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public event Action Attack;

    protected void InvokeAttack()
    {
        Attack?.Invoke();
    }
}
