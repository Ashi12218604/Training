using System;
class Gaming
{
    public static void game()
    {
        Console.WriteLine("GAME BEGINS");
        for(int i = 1; i <= 10; i++)
        {
            if (i == 4)
            {
                Console.WriteLine($"Enemy {i} is invisble. Skipping Enemy {i}");
            }
            else
            {
                Console.WriteLine($"Player Killed Enemy {i}");
            }
        }
    }
}