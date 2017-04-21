﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace MultiplyAndDivideCalculator.Test
{
    [TestClass]
    public class MultiplyAndDivideUnitTest
    {
        [TestMethod]
        public void CalculateNormally()
        {
            //Arrange
            string input = "2*3/1*5=";
            decimal expected = 30;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithTwoOperatorsInARow()
        {
            //Arrange
            string input = "2/*3/1*5=";
            decimal expected = 30;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithOnlyMultiply()
        {
            //Arrange
            string input = "2*3*1*5=";
            decimal expected = 30;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void CalculateWithOnlyDivide()
        {
            //Arrange
            string input = "100/2/2/5=";
            decimal expected = 5;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void DivideDecimalNumbers()
        {
            //Arrange
            string input = "100.2/2/2/5=";
            decimal expected = 5.01m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void DivideTwoDecimalNumbers()
        {
            //Arrange
            string input = "1010.2/2.25=";
            decimal expected = 448.97777777777777777777777778m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MultiplyTwoDecimalNumbers()
        {
            //Arrange
            string input = "1010.2*2.25=";
            decimal expected = 2272.95m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MultiplyManyDecimalNumbers()
        {
            //Arrange
            string input = "1010.2*2.25*56.35*65.45=";
            decimal expected = 8382883.9421250m;

            //Act
            var calculator = new MultiplyDivideCalculator();
            decimal result = calculator.Calculate(input);

            //Assert
            Assert.AreEqual(result, expected);
        }
    }
}
