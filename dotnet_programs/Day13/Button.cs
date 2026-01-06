using System;
class Button
{
    public delegate void ClickHandler();
    public event ClickHandler Clicked; //clicked is an event name
    public void Click()
    {
        Clicked?.Invoke();
    }
}
