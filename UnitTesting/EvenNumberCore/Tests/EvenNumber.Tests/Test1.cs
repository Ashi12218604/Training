using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvenNumber.Core;

namespace EvenNumber.Tests
{
    [TestClass]
    public class EvenNumberServiceTest
    {
        [TestMethod]
        public void ReverseString_WithHello_ReturnsOlleh()
        {
            var service = new EvenNumberService();

            string result = service.ReverseString("hello");

            Assert.AreEqual("olleh", result);
        }
    }
}
