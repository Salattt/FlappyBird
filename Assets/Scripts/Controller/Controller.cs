using System;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public event Action AttackInvoked;

    protected void InvokeAttack()
    {
        AttackInvoked?.Invoke();
    }
}
