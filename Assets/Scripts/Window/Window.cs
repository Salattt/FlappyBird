using UnityEngine;
using UnityEngine.UI;

public  abstract class Window : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _windowGroup;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);   
    }

    protected abstract void OnButtonClick();

    protected void Close()
    { 
        _windowGroup.alpha = 0f;
        _button.interactable = false;
    }

    public void Open()
    {
        _windowGroup.alpha = 1f;
        _button.interactable = true;
    }
}
