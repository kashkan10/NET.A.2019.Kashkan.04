using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoubleExtension;

namespace Tests
{
    [TestClass]
    class DoubleExtensionTests
    {
        [TestMethod]
        public void DoubleToBinTest()
        {
            double number = 255.255;
            string result = number.DoubleToBin();
            string expected = "0100000001101111111010000010100011110101110000101000111101011100";

            Assert.AreEqual(result, expected);
        }
    }
}
