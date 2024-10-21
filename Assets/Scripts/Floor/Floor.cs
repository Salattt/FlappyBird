using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(BoxCollider2D))]
public class Floor : MonoBehaviour, IInteractable
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0f;
    }

    public void TurnOn()
    {
        _animator.speed = 1f;
    }

    public void TurnOff()
    {
        _animator.speed = 0f; 
    }
}
