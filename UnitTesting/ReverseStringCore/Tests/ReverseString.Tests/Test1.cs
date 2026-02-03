using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseString.Core;

namespace ReverseString.Tests
{
    [TestClass]
    public class StringServiceTest
    {
        [TestMethod]
        public void ReverseString_WithHello_ReturnsOlleh()
        {
            var service = new StringService();

            string result = service.ReverseString("hello");

            Assert.AreEqual("olleh", result);
        }
    }
}
