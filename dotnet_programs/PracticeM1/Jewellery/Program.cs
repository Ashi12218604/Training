using System;
using System.Collections;
using System.Collections.Generic;
public class JewelleryUtility
{
    public void GetJewelleryDetails(Jewellery j)
    {
        Console.WriteLine($"{j.Type}, {j.Material},{j.Price}");
    }
    public void UpdateJewelleryPrice(Jewellery j,int price)
    {
        j.Price=price;
        Console.WriteLine($"{j.Price}");
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        string input=Console.ReadLine();
        string[] st=input.Split();
        string id=st[0];
        string type=st[1];
        string material=st[2];
        int pri=int.Parse(st[3]);
        Jewellery j=new Jewellery(id,type,material,pri);
        JewelleryUtility ju=new JewelleryUtility();
        ju.GetJewelleryDetails(j);
        int  newprice=Convert.ToInt32(Console.ReadLine());
        ju.UpdateJewelleryPrice(j,newprice);
    }
}