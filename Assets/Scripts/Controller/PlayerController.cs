using System;
using UnityEngine;

public class PlayerController : Controller
{
    private bool _isPlaying = false;

    public event Action JumpInvoked;

    private void Update()
    {
        CheckInputs();
    }

    public void TurnOn()
    {
        _isPlaying = true;
    }

    public void TurnOff()
    {
        _isPlaying = false;
    }

    private void CheckInputs()
    {
        if (_isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                JumpInvoked?.Invoke();

            if (Input.GetKeyDown(KeyCode.E))
                InvokeAttack();
        }
    }
}
