using System;
class Program
{
    public static void Main()
    {
        int ch;
        do{
            Showmenu();

        Console.WriteLine("Enter choice to perform");
        ch=Convert.ToInt32(Console.ReadLine());
        switch(ch)
        {
            case 1: CreateBill();
            break;
            case 2: ViewLastBill();
            break;
            case 3: ClearLastBill();
            break;
            case 4: Console.WriteLine("Thank you. Application closed normally.");
            break;
            default:
            Console.WriteLine("Invalid Choice. Please enter a valid choice");
            break;
        }

    }
    while( ch!=4);
}

    static void Showmenu()
    {
        Console.WriteLine();
        Console.WriteLine("================== MediSure Clinic Billing ==================");
        Console.WriteLine("1. Create New Bill (Enter Patient Details)");
        Console.WriteLine("2. View Last Bill");
        Console.WriteLine("3. Clear Last Bill");
        Console.WriteLine("4. Exit");
    }
        static void CreateBill()
    {
        PatientBill pb=new PatientBill();
        Console.WriteLine("Enter BillId");
        pb.billid=Console.ReadLine();
        if(string.IsNullOrEmpty(pb.billid))
        {
            Console.WriteLine("Bill Id cannot be empty");
            return;
        }
        Console.WriteLine("Enter Patient name");
      string name=Convert.ToString(Console.ReadLine());
        pb.patientname=name;
        foreach(char ch in name)
        {
            if(!char.IsLetter(ch) && ch !=null)
            {
            Console.WriteLine("Invalid name. Enter a proper name.");
            return ;
        }
        }
        Console.WriteLine("Is the patient insured? (Y/N): ");
        string ins=Console.ReadLine();
        pb.hasinsurance=(ins=="Y"||ins=="y");
         Console.WriteLine("Enter consulation fees");
         pb.consultationfees=Convert.ToDecimal(Console.ReadLine());
         Console.WriteLine("Enter LabChargers and Medicine Charges");
         pb.labcharges=Convert.ToDecimal(Console.ReadLine());
         pb.medcharges=Convert.ToDecimal(Console.ReadLine());
           if (pb.consultationfees <= 0 ||pb.labcharges < 0 || pb.medcharges < 0)
    {
        Console.WriteLine("Invalid charges entered");
        return;
    }
    pb.Calculate();
    PatientBill.LastBill=pb;
    PatientBill.HasLastBill=true;
    Console.WriteLine("Bill Created Successfully");
    Console.WriteLine("Gross Amount     : " + pb.gamount.ToString("F2"));
    Console.WriteLine("Discount Amount  : " + pb.disamount.ToString("F2"));
    Console.WriteLine("Final Payable    : " + pb.finalpay.ToString("F2"));
    }
    static void ViewLastBill()
{
    if (!PatientBill.HasLastBill)
    {
        Console.WriteLine("No bill available. Please create a new bill first.");
        return;
    }

    PatientBill pb = PatientBill.LastBill;

    Console.WriteLine();
    Console.WriteLine("----------- Last Bill -----------");
    Console.WriteLine("Bill Id           : " + pb.billid);
    Console.WriteLine("Patient Name      : " + pb.patientname);
    Console.WriteLine("Insured           : " + (pb.hasinsurance ? "Yes" : "No"));
    Console.WriteLine("Consultation Fee  : " + pb.consultationfees.ToString("F2"));
    Console.WriteLine("Lab Charges       : " + pb.labcharges.ToString("F2"));
    Console.WriteLine("Medicine Charges  : " + pb.medcharges.ToString("F2"));
    Console.WriteLine("Gross Amount      : " + pb.gamount.ToString("F2"));
    Console.WriteLine("Discount Amount   : " + pb.disamount.ToString("F2"));
    Console.WriteLine("Final Payable     : " + pb.finalpay.ToString("F2"));
    Console.WriteLine("--------------------------------");
}
static void ClearLastBill()
{
    PatientBill.LastBill = null;
    PatientBill.HasLastBill = false;
    Console.WriteLine("Last bill cleared.");
}  
} 
