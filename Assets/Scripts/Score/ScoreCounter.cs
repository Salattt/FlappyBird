using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private ScoreView _view;
    private int _counter = 0;

    public void OnEnemyDie(Enemy enemy)
    {
        enemy.Die -= OnEnemyDie;
        enemy.Despawn -= OnEnemyDespawn;

        _counter++;

        _view.UpdateCounter(_counter);
    }

    public void OnEnemyDespawn(Enemy enemy)
    {
        enemy.Despawn -= OnEnemyDespawn;
        enemy.Die -= OnEnemyDie;
    }

    public void ResetComponent()
    {
        _counter = 0;
        _view.UpdateCounter(_counter);
    }
}
