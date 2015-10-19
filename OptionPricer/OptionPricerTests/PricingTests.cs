using NUnit.Framework;
using OptionPricer.Pricing;
using System;

namespace OptionPricerTests
{
    [TestFixture]
    public class PricingTests
    {
        [Test]
        [Ignore("Figure out what the correct value is")]
        public void TestBlackScholesPrice_ATM()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.Strike = 10.0;
            Pricer.Spot = 10.0;
            Assert.AreEqual(0.0, Pricer.Price());
        }

        [Test]
        [Ignore("Figure out what the correct value is")]
        public void TestBlackScholesPrice_ITM()
        //TODO Fix this when BS pricing is fully implemented
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.Strike = 10.0;
            Pricer.Spot = 15.0;
            Assert.AreEqual(5.0, Pricer.Price());
        }

        [Test]
        [Ignore("Figure out what the correct value is")]
        public void TestBlackScholesPrice_OTM()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.Strike = 15.0;
            Pricer.Spot = 10.0;
            Assert.AreEqual(0.0, Pricer.Price());
        }

        [Test]
        public void TestTimeToMaturity()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Assert.AreEqual(1, Pricer.TimeToMaturity());
        }

        [Test]
        public void TestDiscountFactor()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.RiskFreeRate = 1;
            Assert.AreEqual(1/Math.E, Pricer.DiscountFactor());
        }

        [Test]
        public void TestDerivative()
        {
            BSOptionPricer Pricer = new BSOptionPricer();
            Pricer.Strike = 10.0;
            Pricer.Spot = 10.0;
            Pricer.RiskFreeRate = 1;
            Pricer.Volatility = 0.5;
            Assert.AreEqual(2.25, Pricer.Derivative());
            Assert.AreEqual(1.75, Pricer.Derivative(false));
        }
    }
}
