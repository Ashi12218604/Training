// // Online C# Editor for free
// // Write, Edit and Run your C# code using C# Online Compiler

// using System;
// using System.Collections.Generic;
// using System.Linq;
// public class Prog
// {
//     public static Dictionary<char,int> GetFrequency(string input)
//     {
//         Dictionary<char,int> dict=new Dictionary<char,int>();
//         int count=0;
//         foreach(char c in input)
//         {
//             if(dict.ContainsKey(c))
//             dict[c]++;
//             else
//             dict.Add(c,1);
//         }
//         return dict;
//     }
// public static void Main(string[] args)
// {
// string nn=Console.ReadLine();
// Dictionary<char,int> res=GetFrequency(nn);
// foreach (var item in res)
// {
//     Console.WriteLine(item.Key +":"+item.Value);
// }
// }
// }


// using System;
// using System.Linq;
// public class Prog
// {
// public static void Main(string[] args)
// {
//     string s=Console.ReadLine();
//     string w=new string(s.Select(c=>(char)(c+s.Length)).ToArray());
//     Console.WriteLine(w);
// }
// }

// using System;
// using System.Collections.Generic;
// using System.Linq;

// class Member
// {
//     public string Name { get; set; }
//     public List<int> DailyCalories { get; set; }
// }

// class GymManager
// {
//     private List<Member> members = new List<Member>();

//     // Register member
//     public void RegisterMember(Member m)
//     {
//         members.Add(m);
//     }

//     // Get days where calories exceed threshold
//     public List<int> GetHighCalorieDays(List<Member> members, int threshold)
//     {
//         List<int> result = new List<int>();

//         foreach (var member in members)
//         {
//             foreach (var cal in member.DailyCalories)
//             {
//                 if (cal > threshold)
//                     result.Add(cal);
//             }
//         }

//         return result;
//     }

//     // Calculate average calories of all members
//     public double CalculateAverageCalories()
//     {
//         var allCalories = members.SelectMany(m => m.DailyCalories);

//         if (!allCalories.Any())
//             return 0;

//         return allCalories.Average();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         GymManager manager = new GymManager();

//         Member m1 = new Member
//         {
//             Name = "Ashi",
//             DailyCalories = new List<int> { 200, 350, 400 }
//         };

//         Member m2 = new Member
//         {
//             Name = "Rahul",
//             DailyCalories = new List<int> { 150, 500, 300 }
//         };

//         manager.RegisterMember(m1);
//         manager.RegisterMember(m2);

//         var highDays = manager.GetHighCalorieDays(new List<Member> { m1, m2 }, 300);

//         Console.WriteLine("High Calorie Days:");
//         foreach (var c in highDays)
//             Console.WriteLine(c);

//         Console.WriteLine("Average Calories: " + manager.CalculateAverageCalories());
//     }
// }



// using System;
// using System.Collections.Generic;

// public class BankManager
// {
//     // ADD account
//     public static void AddAccount(Dictionary<string, long[]> dict, string accountId)
//     {
//         // TODO: Add account with default values
//     }

//     // LOAN command
//     public static void Loan(Dictionary<string, long[]> dict, string accountId, long amount)
//     {
//         // TODO: Update loan amount

//         dict[accountId][1]+=amount;
//     }

//     // DEPOSIT command
//     public static void Deposit(Dictionary<string, long[]> dict, string accountId, long amount)
//     {
//         // TODO: Update deposit and reduce loan
//         dict[accountId][0]+=amount;
//     }

//     // PRINT command
//     public static void PrintAccount(Dictionary<string, long[]> dict, string accountId)
//     {
//         // TODO: Print account details
//         // Format:
//         // accountId remainingLoan totalLoan totalDeposit
//     }
// }

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Dictionary<string, long[]> accounts = new Dictionary<string, long[]>();

//         // TODO:
//         // 1. Read number of commands
//         // 2. Loop through commands
//         // 3. Parse command
//         // 4. Call correct BankManager function

//     }
// }



using System;
using System.Text.RegularExpressions;
public class Prog
{
public static void Main(string[] args)
{
    string s=Console.ReadLine();
   string w=@"^[A-Za-z][0-9A-Za-z]*@[A-Za-z]+\.(com|org)$";
   if(Regex.IsMatch(s,w))

    Console.WriteLine("valid");
    else 
      Console.WriteLine("invalid");
}
}