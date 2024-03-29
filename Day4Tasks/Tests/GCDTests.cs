using NUnit.Framework;
using GCD;

namespace Tests
{
    public class GCDTests
    {
        [Test]
        public void EuclidTest()
        {
            Assert.AreEqual(Euclid.GCD(-6, 18, 42), 6);
            Assert.AreEqual(Euclid.GCD(126, 540), 18);
            Assert.AreEqual(Euclid.GCD(0, 18), 18);
            Assert.AreEqual(Euclid.GCD(30, 18), 6);
        }

        [Test]
        public void SteinTest()
        {
            Assert.AreEqual(Stein.GCD(-6, 18, 42), 6);
            Assert.AreEqual(Stein.GCD(126, 540), 18);
            Assert.AreEqual(Stein.GCD(0, 18), 18);
            Assert.AreEqual(Stein.GCD(30, 18), 6);
        }
    }
}
