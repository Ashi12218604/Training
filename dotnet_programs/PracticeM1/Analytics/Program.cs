// using System;
// using System.Collections.Generic;

// public enum ActionEnum
// {
//     LOGIN,
//     LOGOUT,
//     PURCHASE,
//     CLICK
// }

// public interface IAnalyticsStore
// {
//     void StoreActions(Queue<ActionEnum> actions);
// }
// public class AnalyticsStore : IAnalyticsStore
// {
//     public void StoreActions(Queue<ActionEnum> actions)
//     {
//         Console.WriteLine("Stored batch:");
//         foreach(var a in actions)
//         {
//             Console.WriteLine(a);
//         }
//     }
// }
// public class Analytics
// {
//     private IAnalyticsStore analyticsStore;
//     private int K;

//     // TODO: Declare buffer queue
//     private Queue<ActionEnum> q;
//     private int totalogged;
//     // TODO: Declare total counter

//     public Analytics(IAnalyticsStore analyticsStore, int K)
//     {
//         // TODO: Initialize variables
//         this.analyticsStore=analyticsStore;
//         this.K=K;
//         this.q=new Queue<ActionEnum>();
//         this.totalogged=0;
//     }


//     public void RegisterAction(ActionEnum action)
//     {
//         // TODO:
//         // 1. Add action to queue
//         q.Enqueue(action);
//         totalogged++;
//         if(q.Count==K)
//         {
//             analyticsStore.StoreActions(new Queue<ActionEnum>(q));
//               q.Clear();
//         }
      
//         // 2. Increase total counter
//         // 3. If queue size == K
//         //      call StoreActions()
//         //      clear queue
//     }

//     public int getNumberOfActionRegisteredButNotSenttoAnalyticsStore()
//     {
//         // TODO: return current queue size
//         return q.Count;
//     }

//     public int getTotalNumberofLoggedActions()
//     {
//         // TODO: return total count
//         return totalogged;
//     }
// }

// public class Program
// {
//     public static void Main()
//     {
//         IAnalyticsStore store=new AnalyticsStore();
//         Analytics analytics=new Analytics(store,4);
//         analytics.RegisterAction(ActionEnum.LOGIN);
//         analytics.RegisterAction(ActionEnum.CLICK);
//         analytics.RegisterAction(ActionEnum.PURCHASE);
//         analytics.RegisterAction(ActionEnum.LOGOUT);
//         analytics.RegisterAction(ActionEnum.LOGIN);
//         Console.WriteLine("Unsent Actions:"+analytics.getNumberOfActionRegisteredButNotSenttoAnalyticsStore());
//         Console.WriteLine("Total logs:"+analytics.getTotalNumberofLoggedActions());
//         // TODO:
//         // 1. Create dummy AnalyticsStore implementation
//         // 2. Create Analytics object
//         // 3. Register some actions
//         // 4. Print unsent count
//         // 5. Print total count
//     }
// }




using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<List<string>> ExtractErrorLogs(List<List<string>> logs)
    {
        // Step 1: Filter
        var filtered = logs
            .Where(log => log[2] == "ERROR" || log[2] == "CRITICAL");

        // Step 2: Stable sort manually by parsing date + time
        var sorted = filtered
            .OrderBy(log =>
            {
                string[] dateParts = log[0].Split('-');
                string[] timeParts = log[1].Split(':');

                int day = int.Parse(dateParts[0]);
                int month = int.Parse(dateParts[1]);
                int year = int.Parse(dateParts[2]);

                int hour = int.Parse(timeParts[0]);
                int minute = int.Parse(timeParts[1]);

                // Return a tuple for sorting priority
                return (year, month, day, hour, minute);
            });

        return sorted.ToList();
    }

    static void Main()
    {
        var logs = new List<List<string>>
        {
            new List<string>{"02-01-2023","1:30","ERROR","failed"},
            new List<string>{"01-01-2023","04:00","INFO","established"}
        };

        var result = ExtractErrorLogs(logs);

        foreach(var log in result)
        {
            Console.WriteLine(
                $"[{string.Join(",", log)}]"
            );
        }
    }
}
