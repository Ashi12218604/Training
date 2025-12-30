using System;

public class Portfolio
{
    public string Name;

    public override bool Equals(object obj)
    {
        Portfolio p = obj as Portfolio; // Typecasting because obj is a general object and so needs to convert it into Portfolio type
        return p != null && p.Name == Name;
    }

    public override int GetHashCode()
    {
         return Name != null ? Name.GetHashCode() : 0;
    }
}
