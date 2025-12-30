using System;
using LogProcessing;
class Program
{
    static void Main(String[] args)
    {
        LogParser parser=new LogParser();
        Console.WriteLine(parser.IsValid("[INF] Application started"));
        Console.WriteLine(parser.IsValid("INVALID LOG"));
        string log="Part1<***>Part2<====>Part3<^*>Part4";
        string[] parts=parser.SplitLogLine(log);
        foreach(string p in parts)
        Console.WriteLine(p);
        string logs="\"password\" failed \"Password\" retry \"passWORD\"";
        Console.WriteLine(parser.countquotespass(logs));
        Console.WriteLine(parser.removelinetext("Processs done"));
        string[] lines=
        {
            "User password123 failed login",
            "System started successfully"
        };
        string[] result=parser.listlineswithapss(lines);
        foreach(string r in result)
        {
            Console.WriteLine(r);
        }
    }
}
