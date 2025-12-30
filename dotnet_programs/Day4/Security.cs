using System;
using System.Collections.Generic;
sealed class Security
{
    public void Authenticate()
    {
        Console.WriteLine("User authenticated successfully\n");
    }
}
abstract class InsurancePolicy
{
    public int PolicyNumber { get; init; }
    private double premium;
    public double Premium
    {
        get => premium;
        set
        {
            if (value > 0)
                premium = value;
            else
                Console.WriteLine("Premium must be greater than zero");
        }
    }
    public string PolicyHolderName { get; set; }
    public InsurancePolicy(int policyNumber, string holderName, double premium)
    {
        PolicyNumber = policyNumber;
        PolicyHolderName = holderName;
        Premium = premium;
    }

    public virtual double CalculatePremium()
    {
        return Premium;
    }

    public void ShowPolicy()
    {
        Console.WriteLine("Insurance Policy");
    }
}
class LifeInsurance : InsurancePolicy
{
    public LifeInsurance(int pno, string name, double prem) : base(pno, name, prem) { }
    public override double CalculatePremium()
    {
        return Premium + 500;
    }
    public new void ShowPolicy()
    {
        Console.WriteLine("Life Insurance Policy");
    }
}
class HealthInsurance : InsurancePolicy
{
    public HealthInsurance(int pno, string name, double prem) : base(pno, name, prem)
    {
        
    }
    public sealed override double CalculatePremium()
    {
        return Premium + 3000;
    }
}
class PolicyDirectory
{
    private List<InsurancePolicy> policies = new List<InsurancePolicy>();
    public void AddPolicy(InsurancePolicy policy)
    {
        policies.Add(policy);
    }
    public InsurancePolicy this[int index]
    {
        get { return policies[index]; }
    }
    public InsurancePolicy? this[string name]
    {
    get
    {
        foreach (var p in policies)
        {
            if (p.PolicyHolderName == name)
                return p;
        }
        return null;
    }
}

}