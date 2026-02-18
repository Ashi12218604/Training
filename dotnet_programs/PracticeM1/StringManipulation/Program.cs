// using System;
// using System.Text;

// class Program
// {
//     static void Main()
//     {
//         string input = Console.ReadLine();

//         int vowelCount = 0;
//         int consonantCount = 0;
//         foreach(char c in input)
//         {
//             if(char.IsLetter(c))
//             {
//             if(c=='a' || c=='e' || c=='i' || c=='o' || c=='u' || c=='A' || c=='E' || c=='I' || c=='O' || c=='U')
//             vowelCount++;
//             else
//             consonantCount++; 
//                    }   
//         }

//         // TODO 1: Count vowels and consonants

//         // TODO 2: Reverse each word
//         string[] arr=input.Split();
//         Array.Reverse(arr);
//         string rev=String.Join(" ",arr);

//         Console.WriteLine("Vowels: " + vowelCount);
//         Console.WriteLine("Consonants: " + consonantCount);
//         Console.WriteLine("Reversed Sentence:"+rev);
//         // foreach(var s in arr)
//         // {
//         //     Console.Write(s+ " ");
//         // }
//         // TODO: Print reversed sentence
//     }
// }


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        Dictionary<int, int> freq = new Dictionary<int, int>();
        // TODO: Count frequency
        foreach(var v in arr)
        {
        if(freq.ContainsKey(v))
        freq[v]++;
        else
        freq[v]=1;
        
        }
        // TODO: Sort and print
        foreach(var v in freq.OrderByDescending(x=>x.Value))
        {
            Console.WriteLine($"{v.Key},{v.Value}");
        }
    }
}
