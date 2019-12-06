using System;

namespace BondYieldCalculator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Console.WriteLine("Choose an option from the following list:");
            Console.WriteLine("\tp - Calculate Price");
            Console.WriteLine("\ty - Calculate Yeild");
            Console.Write("Your option? ");

            switch (Console.ReadLine())
            {
                case "p":
                    Console.WriteLine("Type coupon, and then press Enter");
                    double coupon = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Your result= " + coupon);
                    break;
                case "y":
                    Console.WriteLine();
                    break;
            }

        }
    }
}
