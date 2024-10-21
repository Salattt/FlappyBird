using System;

public class StartScreen : Window
{
    public event Action Start;

    protected override void OnButtonClick()
    {
        Start?.Invoke();
        Close();
    }
}
