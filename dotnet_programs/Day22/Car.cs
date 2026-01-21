using System;
using System.Collections;
public interface ICar
{
    void Gear1();
    void Gear2();
    void Gear3();
    void Gear4();
    void Gear5();
    void Gear6();
}
public class Car:ICar
{
    public void Gear1()
    {
        Console.WriteLine("Tested Gear 1");
    }
      public void Gear2()
    {
        Console.WriteLine("Tested Gear 2");
    }  public void Gear3()
    {
        Console.WriteLine("Tested Gear 3");
    }  public void Gear4()
    {
        Console.WriteLine("Tested Gear 4");
    }  public void Gear5()
    {
        Console.WriteLine("Tested Gear 5");
    }
      public void Gear6()
    {
        Console.WriteLine("Tested Gear 6");
    }
}