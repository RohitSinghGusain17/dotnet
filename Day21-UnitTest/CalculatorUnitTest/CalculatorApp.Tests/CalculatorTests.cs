using System;
using System.Collections.Generic;
using System.Text;
using CalculatorApp;
using CalculatorUnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{

    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int result = calc.Add(10, 5);

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            Calculator calc = new Calculator();
            int result = calc.Subtract(10, 5);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            Calculator calc = new Calculator();
            int result = calc.Multiply(4, 3);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            Calculator calc = new Calculator();

            try
            {
                calc.Divide(10, 0);
                Assert.Fail("Exception was not thrown");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
        }
    }

}
