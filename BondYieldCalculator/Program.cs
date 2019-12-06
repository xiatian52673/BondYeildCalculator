using System;

namespace BondYieldCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Bond Yeild Calculator Console Application in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                Console.WriteLine("Type coupon, and then press Enter");
                double coupon = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Type years, and then press Enter");
                int years = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Type face, and then press Enter");
                double face = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\tp - Calculate Price");
                Console.WriteLine("\ty - Calculate Yeild");
                Console.Write("Your option? ");

                Calculator calculator = new Calculator();


                switch (Console.ReadLine())
                {
                    case "p":

                        Console.WriteLine("Type rate, and then press Enter");
                        double rate = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine($"Your result= " + calculator.CalcPrice(coupon, years, face, rate));

                        break;
                    case "y":

                        Console.WriteLine("Type price, and then press Enter");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine($"Your result= " + calculator.CalcYield(coupon, years, face, price));
                        break;
                }
                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                endApp |= Console.ReadLine() == "n";

                Console.WriteLine("\n"); 
            }
            return;
            

        }
    }
}
