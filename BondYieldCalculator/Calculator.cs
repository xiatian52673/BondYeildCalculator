using System;
namespace BondYieldCalculator
{
    class Calculator
    {
        public double CalcPrice(double coupon, int years, double face, double rate)
        {
            double price = 0, payment = face * coupon;
            for (int year = 1; year <= years; year++)
            {
                price += payment / (Math.Pow(1 + rate, year));
            }
            price += face / (Math.Pow(1 + rate, years));
            return price;
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
            return rate;
        }

    }
    //class CalculatorTest
    //{
    //    static void Main(string[] args)
    //    {
    //        Calculator c = new Calculator();

    //        Console.WriteLine(c.CalcPrice(0.15, 5, 1000, 0.15));
    //        Console.WriteLine(c.CalcYield(0.10, 5, 1000, 1000));

    //        Console.WriteLine(c.CalcPrice(0.10, 5, 1000, 0.08));
    //        Console.WriteLine(c.CalcYield(0.10, 5, 1000, 1079.85));

    //        Console.WriteLine(c.CalcPrice(0.10, 30, 1000, 0.19));
    //        Console.WriteLine(c.CalcYield(0.10, 30, 1000, 528.8807463));


    //    }
    //}

}

