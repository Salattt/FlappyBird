using System;

public class StartScreen : Window
{
    public event Action StartButtonPressed;

    protected override void OnButtonClick()
    {
        StartButtonPressed?.Invoke();
        Close();
    }
}
