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



// using System;
// using System.Text.RegularExpressions;
// public class Prog
// {
// public static void Main(string[] args)
// {
//   int n=Convert.ToInt32(Console.ReadLine());
//     // string p=@"^(EMP\-(HR|IT|FIN|ADM)\-([1-9][0-9][0-9][0-9]))$";
//     string p=@"^([a-z]{4,})([0-9]{3})@company\.org$";
//   for(int i=0;i<n;i++)
// {

//     string s=Console.ReadLine();
  

//     //    string w=@"^[A-Za-z][0-9A-Za-z]*@[A-Za-z]+\.(com|org)$";
//   // string n=@"^(TXN)-\d{6}\|(\d{4})-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])\|(INR|USD|EUR)\|\d{1,6}\.\d{2}\|(SUCCESS|FAIL|PENDING)$";

// // string p=  @"^(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.
//           // (25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.
//           // (25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])\.
//           // (25[0-5]|2[0-4][0-9]|1[0-9]{2}|[1-9]?[0-9])$";
        

//    if(Regex.IsMatch(s,p))

//     Console.WriteLine("valid");
//     else 
//       Console.WriteLine("invalid");
// }
// }
//  }


// using System;
// class Prog
// {
// public static void Main(string[] args)
//     {
//         string s=Console.ReadLine();
//         string[] parts=s.Split('.');
//         if(parts.Length!=4)
//         {
//              Console.WriteLine("Invalid");
//         return ;
//         }
//         foreach(string p in parts)
//         {
//           if(!int.TryParse(p, out int num)) 
//           {     Console.WriteLine("Invalid");
//           return ; 
//           }
//           if(num<0 || num>255)
//           {     Console.WriteLine("Invalid");
//           return ;
//           }
//         }
//      Console.WriteLine("valid");
//     }
// }

// using System;
// using System.Collections.Generic;
// using System.Collections;
// public static class PlaylistManager
// {
//     public static LinkedList<string> playlist=new LinkedList<string>();
//     public static HashSet<string> songs=new HashSet<string>();
//   public static int addSong(string songId)
//   {
//     if(!songs.Contains(songId))
//     {
//       playlist.AddLast(songId);
//       songs.Add(songId);
//     }
//     return 1;
//   }
//   public static int removeSong(string songId)
//   {
//     if(songs.Contains(songId))
//     {
//       playlist.Remove(songId);
//       songs.Remove(songId);
//     }
//     return 1;
//   }
//   public static int moveToTop(string songId)
//   {
//     if(songs.Contains(songId))
//     {
//       playlist.Remove(songId);
//       playlist.AddFirst(songId);
//     }
//     return 1;
//   }
//   public static String getPlaylistOrder()
//   {
//     if(playlist.Count==0)
//     {
//     return "Empty Playlists";
//     }
//    return string.Join(" ",playlist);
//   }
//     public static int processCommands(System.IO.TextReader input,int N)
//   {
//     for(int i=0;i<N;i++)
//     {
//     string inp=input.ReadLine();
//     string[] cmd=inp.Split(' ');
//     if(cmd[0]=="ADD")
//     {
//       addSong(cmd[1]);
//     }
//     else if (cmd[0]=="REMOVE")
//     removeSong(cmd[1]);
//     else if (cmd[0]=="TOP")
//     moveToTop(cmd[1]);
//     else if (cmd[0]=="PRINT")
//     Console.WriteLine(getPlaylistOrder());
//     }
//     return 1;
//   }
//       public static void Main(string[] args)
//     {
//         int N = int.Parse(Console.ReadLine());
//         processCommands(Console.In, N);
//     }
//   }



// using System;
// using System.Collections.Generic;
// using System.Collections;
// using System.Text.RegularExpressions;
// class REG
// {
//   public static void Main(string[] args)
//   {
    
//     int n=Convert.ToInt32(Console.ReadLine());
//     string p=@"^[a-z]{3,}\.[a-z]{3,}\d{4}@(hr|it|finance|admin)\.company\.com$";

//     for(int i=0;i<n;i++)
//     {
//       string input=Console.ReadLine();
//     // string p= @"^[0-9A-Fa-f]{1,4}\:[0-9A-Fa-f]{1,4}\:
//     // [0-9A-Fa-f]{1,4}\:[0-9A-Fa-f]{1,4}\:[0-9A-Fa-f]{1,4}\:
//     // [0-9A-Fa-f]{1,4}\:[0-9A-Fa-f]{1,4}\:[0-9A-Fa-f]{1,4}\::[A-F|0-9]{1}[A-F]{1}\:[A-F|0-9]{1}[A-F]{1}\:[A-F|0-9]{1}[A-F]{1}\:[A-F|0-9]{1}[A-F]{1}\:[A-F|0-9]{1}[A-F]{1}
//     // \:[A-F|0-9]{1}[A-F]{1}$";
//         // string p = @"^[0-9A-Fa-f]{1,4}(\:[0-9A-Fa-f]{1,4}){7}\::([0-9A-F]{2}:){5}[0-9A-F]{2}$";
//     if(Regex.IsMatch(input,p))
//     Console.WriteLine("Valid");
//     else
//     {
//       Console.WriteLine("Invalid");
//     }

//   }
// }
// }


// using System;
// using System.Collections;
// public class Prog
// {
//   public static void Main(string[] args)
//   {
//     string input=Console.ReadLine();
//     string w="";
//     Console.WriteLine(input);
//     if(input.Length>4)
//     {
//     foreach(char c in input)
//     {
//       if (c==' ')
//       break;
//       int p=(int)c;
//       int t=p-input.Length;
//       w+=(char)t;
//     }
//     Console.WriteLine(w);
//     }

//   }
// }

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class REG
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        List<int> results = new List<int>();

        string p = @"^[A-Za-z]{1}[A-Za-z0-9$*%!@_]{1,}\d{1}$";

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (input.Length < 3)
            {
                results.Add(0);
            }
            else if (Regex.IsMatch(input, p))
            {
                results.Add(1);
            }
            else
            {
                results.Add(0);
            }
        }

        // Print all outputs together
      foreach (int res in results)
        {
            Console.WriteLine(res);
        }
    }
}