// Copyright (c) 2019 All Rights Reserved
// FileName: CalculatorTest.cs
// FileType: C# Source file
// Author : Tian Xia
// Created On : 12/5/2019
// Last Modified On : 12/10/2019
// Description : Unit tests built for Calculator.cs

using Xunit;
using BondYieldCalculator;

namespace BondYieldCalculatorTests
{
    public class CalculatorTest
    {

        [Fact]
        public void Test_CalcPrice()
        {
            // Set the accuracy to 10-7, max_iterations to 1000
            var calculator = new Calculator(0.0000001, 1000);

            Assert.Equal(calculator.CalcPrice(0.10, 5, 1000, 0.15), 832.3922451);
            Assert.Equal(calculator.CalcPrice(0.15, 5, 1000, 0.15), 1000);
            Assert.Equal(calculator.CalcPrice(0.10, 5, 1000, 0.08), 1079.8542007);
            Assert.Equal(calculator.CalcPrice(0.10, 30, 1000, 0.19), 528.8807463);

        }

        [Fact]
        public void Test_CalcYield()
        {
            // Set the accuracy to 10-7, max_iterations to 1000
            var calculator = new Calculator(0.0000001, 1000);

            Assert.Equal(calculator.CalcYield(0.10, 5, 1000, 832.4), 0.1499974);
            Assert.Equal(calculator.CalcYield(0.10, 5, 1000, 1000), 0.1);
            Assert.Equal(calculator.CalcYield(0.10, 5, 1000, 1079.85), 0.080001);
            Assert.Equal(calculator.CalcYield(0.10, 30, 1000, 528.8807463), 0.1900000);

        }
    }
}