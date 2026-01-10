using System;

public class Patient
{
    public readonly int PatientId;
    public string Name { get; set; }
    public int Age { get; set; }
    private string medicalHistory;
    public Patient(int id, string name, int age)
    {
        PatientId = id;
        Name = name;
        Age = age;
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
// using System;

public class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public readonly int LicenseNumber;

    public static int TotalDoctors;

    static Doctor()
    {
        TotalDoctors = 0;
    }

    public Doctor(string name, string specialization, int license)
    {
        Name = name;
        Specialization = specialization;
        LicenseNumber = license;
        TotalDoctors++;
    }

    public void PrintDoctorInfo()
    {
        Console.WriteLine($"Doctor Name: {Name}");
        Console.WriteLine($"Specialization: {Specialization}");
        Console.WriteLine($"License Number: {LicenseNumber}");
    }
}

// using System;

public class Cardiologist : Doctor
{
    public string HeartSpecialty { get; set; }

    public Cardiologist(string name, int license, string heartSpecialty)
        : base(name, "Cardiologist", license) 
    {
        HeartSpecialty = heartSpecialty;
    }

    public void PrintCardiologistInfo()
    {
        Console.WriteLine("---- Cardiologist Details ----");
        PrintDoctorInfo(); 
        Console.WriteLine($"Heart Specialty: {HeartSpecialty}");
        Console.WriteLine($"Total Doctors : {Cardiologist.TotalDoctors}");
    }
}

public class AppointmentScheduler
{
    public void ScheduleAppointment(Patient p, Doctor d)
    {
        Console.WriteLine("Appointment scheduled.");
        Console.WriteLine($"Patient: {p.Name}");
        Console.WriteLine($"Doctor: {d.Name}");
    }
    public void ScheduleAppointment(Patient p, Doctor d, DateTime date, string mode = "Offline")
    {
        Console.WriteLine("Appointment Scheduled with Details");
        Console.WriteLine($"Patient: {p.Name}");
        Console.WriteLine($"Doctor: {d.Name}");
        Console.WriteLine($"Appointment scheduled on {date.ToString("f")} via {mode}");
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
    public double ApplyInsurance(int coveragePercent, double billAmount)
    {
        double discount = (billAmount * coveragePercent) / 100.0;
        double finalAmount = billAmount - discount;
        return finalAmount;
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
public class InputValidator
{
    public int ReadAge(string input)
    {
        if (int.TryParse(input, out int age))
        {
            return age;
        }

        throw new Exception("Invalid age input. Please enter a valid number.");
    }
}

public class HospitalSystem
{
    public const string HospitalName = "IHCMS Hospital";
    static HospitalSystem()
    {
        Console.WriteLine("System Booting... Initializing Hospital System");
        Console.WriteLine($"Welcome to {HospitalName}");
    }
}