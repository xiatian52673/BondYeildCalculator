using System;
namespace BondYieldCalculator
{
    public class Calculator
    {
        public double CalcPrice(double coupon, int years, double face, double rate)
        {
            double price = 0, payment = face * coupon;
            for (int year = 1; year <= years; year++)
            {
                price += payment / (Math.Pow(1 + rate, year));
            }
            price += face / (Math.Pow(1 + rate, years));
            return Math.Round(price,7);
        }

        public double CalcYield(double coupon, int years, double face, double price)
        {
            double payment = coupon * face, epsilon = 1;
            double rate = (payment + (face - price) / years) / ((face + price) / 2);
            double estPrice = CalcPrice(coupon, years, face, rate);
            while (Math.Abs(estPrice - price) > 0.0000001)
            {
                if (estPrice > price)
                {
                    rate += epsilon;
                    estPrice = CalcPrice(coupon, years, face, rate);
                }
                else
                {
                    rate -= epsilon;
                    estPrice = CalcPrice(coupon, years, face, rate);
                }
                epsilon /= 2;
            }
            return Math.Round(rate, 7);
        }

    }

}
