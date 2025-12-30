using System;
using System.Text.RegularExpressions;

public class RegexMatch
{
    public static void res()
    {
        //**************************************************************************************************************************
//         string input = "1992-02-23, 1990-01-01,2025";
//         // string input = "23-02-1992";
//            string pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";

//         Match m = Regex.Match(input, pattern);
// Console.WriteLine("for match \n");
//         Console.WriteLine("Year  : " + m.Groups["year"].Value);
//         Console.WriteLine("Month : " + m.Groups["month"].Value);
//         Console.WriteLine("Date  : " + m.Groups["date"].Value);

//                 // string input = "1992-02-23, 1990-01-01";
//         // string pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";

//         MatchCollection mc = Regex.Matches(input, pattern);
//         Console.WriteLine("for matches \n");
//         foreach (Match ma in mc)
//         {
//             Console.WriteLine("Year  : " + ma.Groups["year"].Value);
//             Console.WriteLine("Month : " + ma.Groups["month"].Value);
//             Console.WriteLine("Date  : " + ma.Groups["date"].Value);
//             Console.WriteLine();
//         }
        //**************************************************************************************************************
         string sents = Console.ReadLine();
        string pat = @"a...e";

        Match firstMatch = Regex.Match(sents, pat);
        Console.WriteLine("Match result  : "+firstMatch.Value);
        MatchCollection mc=Regex.Matches(sents, pat);
        Console.Write("Matches result: ");
        foreach (Match match in mc)
        {
            Console.Write(match.Value );
        }
        Console.WriteLine();
    }
}
      
      
        // string pat = @"\d+";
        //string pat = @"\D+";  ->returns nothig in Amount
        // string pat = @"\D";  -> A fro A10B20C30

//  Enter input:      "\.txt"
// 10+20B30C!@_abc _0!\tfile.txt
// Match result  : [.txt]
// Matches result: [.txt]

// Enter input:  "\?"
// 10+20B30C!@_a?bc _0!\tfile.txtC:\abc\file.txt?
// Match result  : ?
// Matches result: ??

// Enter input:   ->@"^lo"
// Hello10+20B30C!@_a?bc _0!\tfile.txtC:\abc\file.txt?
// Match result  : 
// Matches result: 

// Enter input:    ->@"^Hello"
// Hello10+20B30C!@_a?bc _0!\tfile.txtC:\abc\file.txt?
// Match result  : Hello
// Matches result: Hello