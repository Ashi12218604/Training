using System;

public class Solution
{
    public static string Evaluate(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            return "Error:InvalidExpression";

        string[] parts = expression.Split(' ');

        if (parts.Length != 3)
            return "Error:InvalidExpression";

        int a, b;

        if (!int.TryParse(parts[0], out a) || !int.TryParse(parts[2], out b))
            return "Error:InvalidNumber";

        string op = parts[1];

        if (op == "+")
            return (a + b).ToString();
        else if (op == "-")
            return (a - b).ToString();
        else if (op == "*")
            return (a * b).ToString();
        else if (op == "/")
        {
            if (b == 0)
                return "Error:DivideByZero";

            return (a / b).ToString();
        }
        else
            return "Error:UnknownOperator";
    }

    public static void Main()
    {
        string expr = Console.ReadLine();
        Console.WriteLine(Evaluate(expr));
    }
}
