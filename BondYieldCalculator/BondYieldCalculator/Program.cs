// Copyright (c) 2019 All Rights Reserved
// FileName: Program.cs
// FileType: C# Source file
// Author : Tian Xia
// Created On : 12/5/2019
// Last Modified On : 12/10/2019
// Description : Console Application Calculating Bond Yield

//Main console application program which does three things:
//1. Takes the coupon, the time, the face, and the rate, calculate bond price;
//2. Takes the coupon, the time, the face, and the price, calculate bond yield. i.e. return the rate;
//3. Keep track of, and print out, the amount of time it takes the program to calculate the price and yield.

using System;

namespace BondYieldCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Keep a boolean isEnd denoting if the program is ended
            bool isEnd = false;
            Console.WriteLine("Bond Yeild Calculator Console Application in C#\r");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("You can either tell me the coupon, the time, the face, and the rate, I will calculate bond price for you; or tell me the coupon, the time, the face, and the price, I will calculate bond yield. i.e. return the rate for you.\n");
            Console.WriteLine("Let's start by entering the coupon, the time, and the face value");
            Console.WriteLine("-----------------------------------------------------------------\n");

            while (!isEnd)
            {
                // Let the user enter the coupon, the time, the face value first
                Console.WriteLine("Type the coupon, and then press Enter");
                double coupon = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Type the years, and then press Enter");
                int years = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Type the face, and then press Enter");
                double face = Convert.ToDouble(Console.ReadLine());

                // Choose between p: Calculate the Price, and y: Calculate the Yeild
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\tp - Calculate the Price");
                Console.WriteLine("\ty - Calculate the Yeild");
                Console.Write("Your option? ");

                // Calculator takes to variables: accuracy and max_iterations
                // Accroding to the instructions, we set the accuracy to 10-7
                Calculator calculator = new Calculator(0.0000001, 1000);

                switch (Console.ReadLine())
                {
                    // User chose to calculate the price
                    case "p":
                        Console.WriteLine("Type rate, and then press Enter");
                        double rate = Convert.ToDouble(Console.ReadLine());
                        // Keep track of time it takes to calculate the price
                        DateTime startTimePrice = DateTime.Now;
                        Console.WriteLine($"Your result of the price = " + calculator.CalcPrice(coupon, years, face, rate));
                        TimeSpan timeSpanPrice = DateTime.Now - startTimePrice;
                        Console.WriteLine("Time cost to calculate the price = " + String.Format("{0}.{1}", timeSpanPrice.Seconds, timeSpanPrice.Milliseconds.ToString().PadLeft(3, '0')) + " Seconds");

                        break;

                    // User chose to calculate the yield
                    case "y":

                        Console.WriteLine("Type price, and then press Enter");
                        double price = Convert.ToDouble(Console.ReadLine());
                        // Keep track of time it takes to calculate the rate
                        DateTime startTimeYield = DateTime.Now;
                        Console.WriteLine($"Your result of rate = " + calculator.CalcYield(coupon, years, face, price));
                        TimeSpan timeSpanYield = DateTime.Now - startTimeYield;
                        Console.WriteLine("Time cost to calculate the yield = " + String.Format("{0}.{1}", timeSpanYield.Seconds, timeSpanYield.Milliseconds.ToString().PadLeft(3, '0')) + " Seconds");

                        break;
                }
                Console.WriteLine("-----------------------------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                isEnd |= Console.ReadLine() == "n";

                Console.WriteLine("\n");
            }
            return;

        }
    }
}
