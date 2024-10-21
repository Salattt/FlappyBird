using System;

public class EndScreen : Window
{
    public event Action Restart;

    protected override void OnButtonClick()
    {
        Restart?.Invoke();
        Close();
    }
}
