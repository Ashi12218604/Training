using System;

class Program
{
    static void Main(string[] args)
    {
        char again;
        do
        {
            Banking.Run();

            Console.Write("\nDo you want to restart the banking application? (y/n): ");
            again = Convert.ToChar(Console.ReadLine().ToLower());

        } while (again == 'y');
    }
}
