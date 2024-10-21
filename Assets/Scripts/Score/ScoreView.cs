using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _view;

    public void UpdateCounter(int score)
    {
        _view.text = score.ToString();
    }
}
