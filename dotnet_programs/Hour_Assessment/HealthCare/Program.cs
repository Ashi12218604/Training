using System;

class Program
{
    static void Main()
    {
        // Triggers static constructor
        Console.WriteLine(HospitalSystem.HospitalName);

        // PATIENT
        Patient patient = new Patient(101, "Amit", 65);
        patient.SetMedicalHistory("Diabetes, BP");

        Console.WriteLine(patient.GetMedicalHistory());

        // DOCTOR (Child class)
        Cardiologist cardiologist = new Cardiologist(
            "Dr. Neha Sharma",
            98765,
            "Interventional Cardiology"
        );

        cardiologist.PrintCardiologistInfo();

        // APPOINTMENT
        AppointmentScheduler scheduler = new AppointmentScheduler();
        scheduler.ScheduleAppointment(
            patient,
            cardiologist,
            DateTime.Now.AddDays(1),
            "Online"
        );

        // DIAGNOSIS
        DiagnosisService diagnosis = new DiagnosisService();
        string condition = "Normal";
        string risk;
        int age = patient.Age;

        diagnosis.EvaluatePatient(
            in age,
            ref condition,
            out risk,
            85, 90, 88
        );

        Console.WriteLine($"Condition: {condition}");
        Console.WriteLine($"Risk Level: {risk}");

        // BILLING
        BillingService billing = new BillingService
        {
            ConsultationFee = 500,
            TestCharges = 2000,
            RoomCharges = 3000
        };

        double billAmount = billing.CalculateBill(500, 250);
        Console.WriteLine($"Total Bill: {billAmount}");

        // INSURANCE
        InsuranceService insurance = new InsuranceService();
        double finalAmount = insurance.ApplyInsurance(20, billAmount);
        Console.WriteLine($"Final Amount After Insurance: {finalAmount}");

        // STAY CALCULATOR
        StayCalculator stay = new StayCalculator();
        Console.WriteLine($"Stay Days: {stay.CalculateStayDays(5)}");
    }
}
