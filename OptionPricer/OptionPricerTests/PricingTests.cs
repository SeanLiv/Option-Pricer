using NUnit.Framework;
using OptionPricer.Pricing;

namespace OptionPricerTests
{
    [TestFixture]
    public class PricingTests
    {
        [Test]
        public void TestBlackScholesPrice_ATM()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.Strike = 10.0;
            Pricer.Spot = 10.0;
            Assert.AreEqual(0.0, Pricer.Price());
        }

        [Test]
        public void TestBlackScholesPrice_ITM()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.Strike = 10.0;
            Pricer.Spot = 15.0;
            Assert.AreEqual(5.0, Pricer.Price());
        }

        [Test]
        public void TestBlackScholesPrice_OTM()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.Strike = 15.0;
            Pricer.Spot = 10.0;
            Assert.AreEqual(0.0, Pricer.Price());
        }
    }
}
