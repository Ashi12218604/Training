using System;

public class Patient
{
    public int PatientId { get; }
    public string Name { get; set; }
    public int Age { get; set; }
    private string medicalHistory;
    public Patient()
    {
        PatientId = new Random().Next(1000, 9999);
        Name = "Unknown";
        Age = 0;
    }
    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
    }
    public Patient(string name)
    {
        PatientId = new Random().Next(1000, 9999);
        Name = name;
        Age = 0;
    }
    public void SetMedicalHistory(string history)
    {
        medicalHistory = history;
    }
    public string GetMedicalHistory()
    {
        return $"Confidential Medical Data: {medicalHistory}";
    }
}
public class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public readonly int LicenseNumber;
    public static int TotalDoctors;
    static Doctor()
    {
        TotalDoctors = 0;
        Console.WriteLine("Doctor system initialized");
    }
    public Doctor(string name, string specialization, int license)
    {
        Name = name;
        Specialization = specialization;
        LicenseNumber = license;
        TotalDoctors++;
    }
}
public class Appointment
{
    public void ScheduleAppointment()
    {
        Console.WriteLine("Basic appointment scheduled.");
    }

    public void ScheduleAppointment(DateTime date)
    {
        Console.WriteLine($"Appointment scheduled on {date}");
    }

    public void ScheduleAppointment(DateTime date, string mode = "Offline")
    {
        Console.WriteLine($"Appointment scheduled on {date} via {mode}");
    }
}
public class MedicalRecord
{
    private string diagnosis;
    private string history;
    public void SetRecord(string diagnosis, string history)
    {
        this.diagnosis = diagnosis;
        this.history = history;
    }
    public string GetDiagnosis()
    {
        return $"Diagnosis: {diagnosis}";
    }
    public string GetHistory()
    {
        return $"Medical History: {history}";
    }
}
public class DiagnosisService
{
    public void EvaluatePatient(in int age, ref string condition, out string riskLevel, params int[] testScores)
    {
        int avg = CalculateAverage(testScores);

        condition = avg > 70 ? "Critical" : "Stable";

        if (age > 60 && avg > 70)
            riskLevel = "High Risk";
        else if (avg > 50)
            riskLevel = "Medium Risk";
        else
            riskLevel = "Low Risk";

        int CalculateAverage(int[] scores)
        {
            int sum = 0;
            foreach (var s in scores) sum += s;
            return scores.Length == 0 ? 0 : sum / scores.Length;
        }
        // static void ExampleStaticLocal()
        // {
        //     // cannot access outer variables here
        //     // because static local functions are isolated
        // }
    }
}
public class BillingService
{
    public double ConsultationFee { get; set; }
    public double TestCharges { get; set; }
    public double RoomCharges { get; set; }
    public double CalculateBill()
    {
        return ConsultationFee + TestCharges + RoomCharges;
    }
    public double CalculateBill(double discount)
    {
        return CalculateBill() - discount;
    }
    public double CalculateBill(double discount, double tax)
    {
        return (CalculateBill() - discount) + tax;
    }
}
public class InsuranceService
{
    public double ApplyInsurance(string coveragePercent, string billAmount)
    {
        double amount;
        double percent;
        double.TryParse(billAmount, out amount);
        double.TryParse(coveragePercent, out percent);
        double coverage = (percent / 100) * amount;
        double remaining = amount - coverage;
        return remaining;
    }
}
public class StayCalculator
{
    public int CalculateStayDays(int days)
    {
        if (days == 0)
            return 0;
        return 1 + CalculateStayDays(days - 1);
    }
}
public class InputHelper
{
    public static void ValidateAge(int age)
    {
        if (age <= 0)
            throw new Exception("Invalid patient age!");
    }
    public static void ValidateBill(double amount)
    {
        if (amount < 0)
            throw new Exception("Billing amount cannot be negative!");
    }
}
public static class HospitalSystem
{
    public static string HospitalName;
    public static string Config;
    static HospitalSystem()
    {
        HospitalName = "IHCMS Super Hospital";
        Config = "System Ready";
        Console.WriteLine("Hospital System Initialized...");
    }
}