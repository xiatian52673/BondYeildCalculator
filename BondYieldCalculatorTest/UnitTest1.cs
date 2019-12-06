using System;
using BondYieldCalculator;
using Xunit;

namespace BondYieldCalculatorTest
{
    public class CalculatorTest
    {
        [Fact]
        public void Test_CalcPrice()
        {
            var calculator = new Calculator();

            Assert.Equal(calculator.CalcPrice(0.10, 5, 1000, 0.15), 832.3922451);
            Assert.Equal(calculator.CalcPrice(0.15, 5, 1000, 0.15), 1);
            Assert.Equal(calculator.CalcPrice(0.10, 5, 1000, 0.08), 1079.8542007);
            Assert.Equal(calculator.CalcPrice(0.10, 30, 1000, 0.19), 528.8807463);

        }

        [Fact]
        public void Test_CalcYield()
        {
            var calculator = new Calculator();
            Assert.Equal(calculator.CalcYield(0.10, 5, 1000, 832.4), 0.1499974);
            Assert.Equal(calculator.CalcPrice(0.10, 5, 1000, 1000), 0.1);
            Assert.Equal(calculator.CalcPrice(0.10, 5, 1000, 1079.85), 0.0800001);
            //Assert.Equal(calculator.CalcPrice(0.10, 5, 1000, 528.8807463), );

        }
    }
}
