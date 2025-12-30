using System;

class FixedDeposit : BankAccount
{
    int timePeriod;
    double fdAmount;
    double roi;

    public FixedDeposit(int accNo, double bal, double fdAmt, double rate, int time)
        : base(accNo, bal)
    {
        fdAmount = fdAmt;
        roi = rate;
        timePeriod = time;
    }

    public double CalculateMaturity()
    {
        double interest = (fdAmount * roi * timePeriod) / 100;
        return fdAmount + interest;
    }

    public void DisplayFD()
    {
        DisplayAccount();
        Console.WriteLine("FD Amount  : ₹" + fdAmount);
        Console.WriteLine("ROI        : " + roi + "%");
        Console.WriteLine("Time       : " + timePeriod + " years");
        Console.WriteLine("Maturity   : ₹" + CalculateMaturity());
    }
}
