using System;
using System.Collections;
namespace UltraEnterpriseSDLC
{
    public sealed class Requirement
    {
        public int Id{get;set;}
        public string Title{get;set;}
        public RiskLevel Risk{get;}
    
    Requirement(int id, string title, RiskLevel risk)
        {
            int Id=id;
            string Ttile=title;
            RiskLevel Risk=risk;
 
        }
}

}