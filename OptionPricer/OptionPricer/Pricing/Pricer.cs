using System;

namespace OptionPricer.Pricing
{
    public class BSOptionPricer
    {
        public enum OptionType { Put, Call };

        public double Strike { get; set; }
        public double Spot { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double RiskFreeRate { get; set; }
        public double Volatility { get; set; }
        public OptionType Type { get; set; }

        public double Price()
        {
            double a = Phi(Derivative()) * this.Spot;
            double b = Phi(Derivative(false)) * this.Strike * DiscountFactor();
            return a - b;
        }

        public int TimeToMaturity()
        {
            return 1;
        }

        public double DiscountFactor()
        {
            double exp = -1 * this.RiskFreeRate * TimeToMaturity();
            return Math.Pow(Math.E, exp);
        }

        public double Derivative(bool positive=true)
        {
            double a = 1 / (this.Volatility * Math.Sqrt(TimeToMaturity()));
            double b = Math.Log(this.Spot / this.Strike);
            double volSquare = this.Volatility * this.Volatility;
            double c = 1.0;
            if (positive == true)
            {
                c = this.RiskFreeRate + (volSquare / 2);
            }
            else
            {
                c = this.RiskFreeRate - (volSquare / 2);
            }
            double d = b + (c * TimeToMaturity());
            return a * d;
        }

        private static double Phi(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x) / Math.Sqrt(2.0);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return 0.5 * (1.0 + sign * y);
        }

    }

}
