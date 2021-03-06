﻿using System;
using Logger.Common.Enum;
using Logger.Common.Formatters;
using Logger.Configuration;
using Logger.Contracts;
using Logger.Factory;
using Logger.Loggers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Logger.Test.UnitTests
{
    [TestClass]
    public class ConsoleLoggerTests
    {
        [TestMethod]
        public void LogStringDoesNotCallSerializer()
        {
            //Arrange
            var mockSerializer = new Mock<ISerializer>(MockBehavior.Strict);
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var logger = LoggerFactory.GetLogger(LoggerType.ConsoleLogger);
            string input = "this is a string";

            //Act
            logger.Log(input);

            //Assert
            //with strict mock behavior if serializer is called an exception will be thrown
        }

        [TestMethod]
        public void LogObjectCallsSerializerCorrectly()
        {
            // Arrange
            var mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new ConsoleLogger(serializer, console, formatter);
            var input = new { a = 13, b = "strings" };
            mockSerializer.Setup(x => x.Serialize(input)).Returns("123");

            //Act
            logger.Log(input);

            //Assert
            mockSerializer.Verify(x => x.Serialize(input), Times.Once);
        }

        [TestMethod]
        public void LogStringWithConsoleOptionsForColors()
        {
            // Arrange
            var mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new ConsoleLogger(serializer, console, formatter, ConsoleColor.DarkBlue, ConsoleColor.DarkMagenta);
            var input = "strings";

            //Act
            logger.Log(input);

            //Assert
            mockConsole.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
            mockConsole.VerifySet(x => x.BackgroundColor = ConsoleColor.DarkMagenta);
            mockConsole.VerifySet(x => x.ForegroundColor = ConsoleColor.DarkBlue);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void LogNullObjectThrowsArgumentNullException()
        {
            // Arrange
            var mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new ConsoleLogger(serializer, console, formatter);
            var input = default(FactoryOptions);

            //Act
            logger.Log(input);

            //Assert
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void LogNullStringThrowsArgumentNullException()
        {
            // Arrange
            var mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new ConsoleLogger(serializer, console, formatter);
            string input = null;

            //Act
            logger.Log(input);

            //Assert
        }

        [TestMethod]
        public void LogEmptyStringUsesConsoleLoggerCorrectly()
        {
            // Arrange
            var mockSerializer = new Mock<ISerializer>();
            var serializer = mockSerializer.Object;
            var mockConsole = new Mock<IConsole>();
            var console = mockConsole.Object;
            var format = new Mock<IFormatter>();
            var formatter = format.Object;
            var logger = new ConsoleLogger(serializer, console, formatter);
            string input = string.Empty;

            //Act
            logger.Log(input);

            //Assert
            mockConsole.Verify(x => x.WriteLine(It.IsAny<string>()));
            format.Verify(x => x.Format(It.IsAny<string>()));
        }
    }
}
