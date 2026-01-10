using System;
public class PatientBill
{
    public string billid;
    public string patientname;
    public decimal consultationfees;
    public decimal labcharges;
    public decimal medcharges;
    public decimal gamount;
    public decimal disamount;
    public decimal finalpay;
    public bool hasinsurance;

    public static PatientBill LastBill;
    public static bool HasLastBill = false;
 public void Calculate()
    {
        gamount=consultationfees+labcharges+medcharges;
        if(hasinsurance==true)
        {
            disamount=gamount*0.10m;
        }
        else 
        {
        disamount=0;
        }
        finalpay=gamount-disamount;

    }

  
}