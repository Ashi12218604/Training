using System;
public abstract class NanoCar
{
    public abstract void Gear1();
    public abstract void Gear2();
    public abstract void Gear3();
    public virtual void Audio()
    {
        Console.WriteLine("Tested Gear4 Audio");
    }
    public virtual void Gear5()
    {
        Console.WriteLine("Tested Gear5");
    }
}
public class Nano:NanoCar
{
        public override void Gear1()
    {
        Console.WriteLine("Tested Gear 1");
    }
      public override void Gear2()
    {
        Console.WriteLine("Tested Gear 2");
    }  public override void Gear3()
    {
        Console.WriteLine("Tested Gear 3");
    } 
}