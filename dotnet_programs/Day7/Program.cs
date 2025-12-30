// using System;
// class Program
// {
//     public static void Main(String[] args)
//     {
//         // Arrays.print();
//         // Console.WriteLine();
//         // Matrix.Calculate();
//         // Console.WriteLine();
//         // Jagged.Create();
//         // Console.WriteLine();
//         // Copy.Cp();
//         // Console.WriteLine();
//         // Exists.Ex();
//         // Console.WriteLine();
//         // Lists.ls();
//         // Console.WriteLine();
//         // Hashtables.hs();
//         // Console.WriteLine();
//         // Queues.q();
//         //  Console.WriteLine();
//         // Stacks.SK();
//         // Console.WriteLine();
//         // Diction.DT();
//         // Console.WriteLine();
//         // Hashsets.hs();
//         // Console.WriteLine();
//         // Sortedlists.Stl();
//         // Console.WriteLine();
//         // Frequency.freq();
//         // Console.WriteLine();
//         Scenario sc=new Scenario();
//        Console.Write("Enter input string: ");
//         string input=Console.ReadLine();
//         string result=sc.cleansandinvert(input);
//         if (result == "")
//             Console.WriteLine("Invalid input");
//         else
//             Console.WriteLine("New String is: " + result);
//         // ********************************************************************************************************************

        using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        HRPayRoll HR = new HRPayRoll();
         while (true)
        {
            Console.WriteLine("1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit\n");

            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            if (choice == 1)
            {
                Console.WriteLine("Select Employee Type (1-Full Time, 2-Contract):");
                int type = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Enter Employee Name:");
                string name = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Enter Hourly Rate:");
                double rate = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();

                double[] hours = new double[4];
                Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                for (int i = 0; i < 4; i++)
                {
                    hours[i] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine();

                if (type == 1)
                {
                    Console.WriteLine("Enter Monthly Bonus:");
                    double bonus = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();

                    FullTimeEmployee f = new FullTimeEmployee()
                    {
                        EmployeeName = name,
                        HourlyRate = rate,
                        MonthlyBouns = bonus,
                        WeeklyHours = hours
                    };

                    HR.RegisterEmployee(f);
                }
                else
                {
                    ContractEmployee c = new ContractEmployee()
                    {
                        EmployeeName = name,
                        HourlyRate = rate,
                        WeeklyHours = hours
                    };

                    HR.RegisterEmployee(c);
                }

                Console.WriteLine("Employee registered successfully\n");
            }

            else if (choice == 2)
            {
                Console.WriteLine("Enter hours threshold:");
                double threshold = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                var result = HR.GetOvertimeWeekCounts(HRPayRoll.PayrollBoard, threshold);
                if (result.Count == 0)
                {
                    Console.WriteLine("No overtime recorded this month\n");
                }
                else
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.Key + " - " + item.Value);
                    }
                    Console.WriteLine();
                }
            }

            else if (choice == 3)
            {
                double avg = HR.CalAvgMP();
                Console.WriteLine("Overall average monthly pay: " + avg + "\n");
            }

            else if (choice == 4)
            {
                Console.WriteLine("Logging off — Payroll processed successfully!");
                break;
            }

            else
            {
                Console.WriteLine("Invalid choice\n");
            }
        }
    }
}

//     }
// }