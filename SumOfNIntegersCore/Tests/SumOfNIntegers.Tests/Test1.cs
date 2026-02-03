using Microsoft.VisualStudio.TestTools.UnitTesting;
using SumOfNIntegers.Core;

namespace SumOfNIntegers.Tests
{
    [TestClass]
    public class SumServiceTest
    {
        [TestMethod]
        public void SumOfNIntegers_With10_Returns45()
        {
            var service = new SumService();

            int result = service.SumOfNIntegers(10);

            Assert.AreEqual(45, result);
        }
    }
}
