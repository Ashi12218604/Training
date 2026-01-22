using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  dllJ;

public interface ClassRoom
{
    public void fan();
    public void light();
}
public interface Library
{
    public void Books();
}
public interface StaffRoom
{
    public void Monitors();
}
public class SchoolBuilding : ClassRoom, Library, StaffRoom
{
    public void fan()
    {
        Console.WriteLine("Fan is not working");
    }
    public void light()
    {
        Console.WriteLine("Light is Working");
    }
    public void Books()
    {
        Console.WriteLine("100 Books are available in Library");
    }
    public void Monitors()
    {
        Console.WriteLine("Few Monitors are available");
    }
}
public class SchoolBluePrint : SchoolBuilding
{
    public void FullBuilding()
    {
        Console.WriteLine("Full building print is avaliable");
    }
}