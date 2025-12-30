using System;
using System.Collections.Generic;
public abstract class EmployeeRecord
{
    public string EmployeeName{get; set;} 
    public double[] WeeklyHours{get; set;}
    public abstract double GetMonthlyPay();
}
public class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate{get; set;}
    public double MonthlyBouns{get; set;}
    public override double GetMonthlyPay()
    {
        double totalHours = WeeklyHours.Sum();
        return (totalHours * HourlyRate) + MonthlyBouns;
    }
}
public class ContractEmployee : EmployeeRecord
{
    public double HourlyRate{get; set;}
    public override double GetMonthlyPay()
    {
        double totalHours = WeeklyHours.Sum();
        return totalHours * HourlyRate;
    }
}
public class HRPayRoll
    {
        public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();
        public void RegisterEmployee(EmployeeRecord record)
    {
        PayrollBoard.Add(record);
    }
    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> res = new Dictionary<string, int>();
        foreach (var e in records)
        {
            int count = 0;
            foreach (double h in e.WeeklyHours)
            {
                if (h >= hoursThreshold)
                {
                    count++;
                }
                if (count > 0)
                {
                    res[e.EmployeeName] = count;
                }
            }
        }
        return res;
    }
    public double CalAvgMP()
    {
        if(PayrollBoard.Count == 0)
        {
            return 0;
        }
        double total = 0;
        foreach (var ea in PayrollBoard)
        {
            total += ea.GetMonthlyPay();
        }
        return total/PayrollBoard.Count;
    }
    }