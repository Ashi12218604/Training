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


// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Program
// {
//     static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());
//         int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

//         Dictionary<int, int> freq = new Dictionary<int, int>();
//         // TODO: Count frequency
//         foreach(var v in arr)
//         {
//         if(freq.ContainsKey(v))
//         freq[v]++;
//         else
//         freq[v]=1;
        
//         }
//         // TODO: Sort and print
//         foreach(var v in freq.OrderByDescending(x=>x.Value))
//         {
//             Console.WriteLine($"{v.Key},{v.Value}");
//         }
//     }
// }




// using System;

// delegate double BonusCalculator(double salary);

// class Program
// {
//     static void Main()
//     {
//         double salary = double.Parse(Console.ReadLine());

//         // TODO: Assign method using lambda
//         BonusCalculator b = s =>
//         {
//             if(s<30000)
//             return (s+(s*0.10));
//             else if(s<60000)
//             return s+(s*0.15);
//             else
//             return s+(s*0.20);
//         };

//         // TODO: Calculate bonus
//         double final=b(salary);

//         Console.WriteLine("Final Salary: " + final);
//     }
// }


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         int n = int.Parse(Console.ReadLine());

//         List<string> codes = new List<string>();

//         for (int i = 0; i < n; i++)
//         {
//             codes.Add(Console.ReadLine());
//         }

//         foreach (string code in codes)
//         {
//             int result = Validate(code);
//             Console.WriteLine(result);
//         }
//     }

//     static int Validate(string code)
//     {
//         if(!char.IsLetter(code[0]))
//         return 0;
//         else if(!char.IsDigit(code[code.Length-1]))
//         return 0;
//         else if(code.Length<3)
//         return 0;
//         else
//         return 1;
//         // TODO:
//         // 1. Check minimum length
//         // 2. Check first character is letter
//         // 3. Check last character is digit
//         // 4. Return 1 if valid else 0

//      // temporary
//     }
// }


using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
public class Student
{
    public string Name{get;set;}="";
    public int Age{get;set;}
    public int RollNo{get;set;}
}
public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int,Student> dict=new Dictionary<int,Student>();
        string input=Console.ReadLine();
        string[] st=input.Split(',');
        foreach(string stri in st)
        {
            string[] str=stri.Trim().Split();
        string name=str[0];
        int age=Convert.ToInt32(str[1]);
        int rno=int.Parse(str[2]);
        
         Student s=new Student(){Name=name,Age=age,RollNo=rno};
         dict.Add(rno,s);
        }
        // var v= dict.OrderByDescending(x=>x.Value.Age).First();
        var ve = dict.Where(x=>x.Value.Age>20);
        foreach(var v in ve)
        {
            Console.Write(v.Value.Name+" ");
        }
   }
}