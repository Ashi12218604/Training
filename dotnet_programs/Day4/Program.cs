using System;

class Program
{
    static void Main()
    {
    //     // --- Bank & Employee ---
    //     BankAccount acc1 = new BankAccount(101, 10000.0);
    //     acc1.DisplayAccount();
    //     acc1.Deposit(2000);

    //     // --- Product Section ---
    //     Product prod = new Product 
    //     {
    //         Name = "Laptop",
    //         Price = 50000
    //     };
    //     Console.WriteLine("Product: " + prod.Name);
    //     Console.WriteLine("Price: " + prod.Price);

    //     // --- Student Section ---
    //     Student s = new Student();
    //     s.Name = "Amit";
    //     s.Age = 20;
    //     s.Marks = 85;

    //     Console.WriteLine("Student Name: " + s.Name);
    //     Console.WriteLine("Age: " + s.Age);
    //     Console.WriteLine("Marks: " + s.Marks);

    //     // --- Healthcare System ---
    //     Console.WriteLine("Hospital: " + HospitalSystem.HospitalName);

    //     Patient pat = new Patient(101, "Sanju", 22); 
    //     pat.SetMedicalHistory("Asthma History");

    //     Doctor d = new Doctor("Dr. Mehta", "Neurologist", 9001);
        
    //     Appointment app = new Appointment();
    //     app.ScheduleAppointment(DateTime.Now, "Online");

    //     DiagnosisService ds = new DiagnosisService();
    //     string condition = "Unknown";
    //     string risk;
    //     int patientAge = pat.Age; 
        
    //     ds.EvaluatePatient(in patientAge, ref condition, out risk, 80, 75, 60);
    //     Console.WriteLine($"Condition: {condition}, Risk: {risk}");

    //     BillingService bill = new BillingService
    //     {
    //         ConsultationFee = 500,
    //         TestCharges = 2000,
    //         RoomCharges = 4000
    //     };
    //     double total = bill.CalculateBill();

    //     InsuranceService ins = new InsuranceService();
    //     double finalPay = ins.ApplyInsurance("40", total.ToString());
    //     Console.WriteLine($"Final Payable Amount: {finalPay}");
    // *************************************************************************
    Security sec = new Security();
        sec.Authenticate();
        LifeInsurance L = new LifeInsurance(102, "Ashi", 5000);
        HealthInsurance H = new HealthInsurance(205, "Arnav", 5000);
        PolicyDirectory D = new PolicyDirectory();
        D.AddPolicy(L);
        D.AddPolicy(H);
        InsurancePolicy p1 = L;
        InsurancePolicy p2 = H;
        Console.WriteLine(D[0].PolicyHolderName);
        var policy = D["Ashi"];
        if (policy != null)
        {
            Console.WriteLine(policy.PolicyNumber);
        }
        else
        {
            Console.WriteLine("Policy not found");
        }
        Console.WriteLine("Life Premium: " + p1.CalculatePremium());
        Console.WriteLine("Health Premium: " + p2.CalculatePremium());
        L.ShowPolicy();           // Derived reference
        p1.ShowPolicy();
    }
}