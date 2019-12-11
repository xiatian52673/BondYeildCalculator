// Copyright (c) 2019 All Rights Reserved
// FileName: Calculator.cs
// FileType: C# Source file
// Author : Tian Xia
// Created On : 12/5/2019
// Last Modified On : 12/10/2019
// Description : Class Calculator Calculating Bond Yield

// Calculator class takes two variables: double accuracy, int max_iterations
// Has two functions do:
//1. Takes the coupon, the time, the face, and the rate, calculate bond price;
//2. Takes the coupon, the time, the face, and the price, calculate bond yield. i.e. return the rate;

using System;
namespace BondYieldCalculator
{
    public class Calculator
    {
        readonly double accuracy;
        readonly int max_iterations;

        public Calculator(double accuracy, int max_iterations)
        {
            this.accuracy = accuracy;
            this.max_iterations = max_iterations;
        }

        public double CalcPrice(double coupon, int years, double face, double rate)
        {
            double price = 0, payment = face * coupon;
            for (int year = 1; year <= years; year++)
            {
                price += payment / (Math.Pow(1 + rate, year));
            }
            price += face / (Math.Pow(1 + rate, years));

            // Round result to the accuracy
            return Math.Round(price, Convert.ToInt32( - Math.Log10(accuracy)));
        }

        public double CalcYield(double coupon, int years, double face, double price)
        {
            double couponPayment = coupon * face;
            double delta = 1;
            int num_iterations = 0;
            // Initial value of rate
            double rate = (((face - price) / years) + couponPayment) / ((face + price) / 2);
            double estPrice = CalcPrice(coupon, years, face, rate);

            // Start the iterations to update rate
            // Until reaching accuracy or max iteration steps
            while (Math.Abs(estPrice - price) > accuracy && num_iterations < max_iterations)
            {
                if (estPrice > price)
                {
                    rate += delta;
                }
                else
                {
                    rate -= delta;
                }
                estPrice = CalcPrice(coupon, years, face, rate);
                delta /= 2;
                num_iterations++;
            }
            // Round result to the accuracy
            return Math.Round(rate, Convert.ToInt32( - Math.Log10(accuracy)));
        }

    }

}
