class Parent
{
    public void Show()
    {
        Console.WriteLine("Parent Show");
    }
}


class Child : Parent
{
    public new void Show()
    {
        Console.WriteLine("Child Show");
    }
}