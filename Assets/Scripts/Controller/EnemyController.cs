using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField] private float _shootTime;

    private float _timer;

    private void OnEnable()
    {
        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > _shootTime)
        {
            InvokeAttack();

            _timer = 0;
        }

    }
}
