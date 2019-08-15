using NUnit.Framework;
using DoubleExtension;

namespace Tests
{
    class DoubleExtensionTests
    {
        [Test]
        public void DoubleToBinTest1()
        {
            double number = 255.255;
            string result = number.DoubleToBin();
            string expected = "0100000001101111111010000010100011110101110000101000111101011100";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBinTest2()
        {
            double number = -255.255;
            string result = number.DoubleToBin();
            string expected = "1100000001101111111010000010100011110101110000101000111101011100";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBinTest3()
        {
            double number = 4294967295.0;
            string result = number.DoubleToBin();
            string expected = "0100000111101111111111111111111111111111111000000000000000000000";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBinTest4()
        {
            double number = 0.0;
            string result = number.DoubleToBin();
            string expected = "0000000000000000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBinTest5()
        {
            double number = -0.0;
            string result = number.DoubleToBin();
            string expected = "1000000000000000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBin_PositiveInfinity_Test()
        {

            double number = double.PositiveInfinity;
            string result = number.DoubleToBin();
            string expected = "0111111111110000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBin_NegatInfinity_Test()
        {
            double number = double.NegativeInfinity;
            string result = number.DoubleToBin();
            string expected = "1111111111110000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBin_NaN_Test()
        {
            double number = double.NaN;
            string result = number.DoubleToBin();
            string expected = "1111111111110000000000000000000000000000000000000000000000000000";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBin_MaxValue_Test()
        {
            double number = double.MaxValue;
            string result = number.DoubleToBin();
            string expected = "0111111111101111111111111111111111111111111111111111111111111111";

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void DoubleToBin_MinValue_Test()
        {
            double number = double.MinValue;
            string result = number.DoubleToBin();
            string expected = "1111111111101111111111111111111111111111111111111111111111111111";

            Assert.AreEqual(result, expected);
        }
    }
}
