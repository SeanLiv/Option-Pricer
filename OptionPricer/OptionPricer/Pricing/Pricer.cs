using System;

namespace OptionPricer.Pricing
{
    public class BSOptionPricer
    {
        enum OptionType { Put, Call };
        public double Strike { get; set; }
        public double Spot { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double DiscountFactor { get; set; }
        public double Volatility { get; set; }

        public double Price()
        {
            return this.Spot - this.Strike;
        }

    }
}
