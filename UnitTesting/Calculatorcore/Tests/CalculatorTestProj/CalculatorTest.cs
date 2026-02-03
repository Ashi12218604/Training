using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcUnitTesting.core;

namespace CalculatorTestProj
{
[TestClass]
public class CalculatorTest
{
    [TestMethod]
    public void Add_Test()
    {
        Calculator calc = new Calculator();
        int result = calc.Add(2, 3);
        Assert.AreEqual(5, result);
         int resut = calc.Add(2, 3);
        Assert.AreEqual(7, resut);
    }

    [TestMethod]
    public void Sub_Test()
    {
        Calculator calc = new Calculator();
        Assert.AreEqual(2, calc.Sub(5, 3));
    }
}

}
