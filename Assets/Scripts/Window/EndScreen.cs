using System;

public class EndScreen : Window
{
    public event Action RestartButtonPressed;

    protected override void OnButtonClick()
    {
        RestartButtonPressed?.Invoke();
        Close();
    }
}
