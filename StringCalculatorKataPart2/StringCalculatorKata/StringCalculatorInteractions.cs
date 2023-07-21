using Castle.Core.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculatorInteractions
    {
        [Theory]
        [InlineData("15", "15")]
        [InlineData("1,2", "3")]
        public void ResultsAreLogged(string numbers, string expectedToBeLogging)
        {
            var loggerMock = new Mock<ILogger>();
            var calculator = new StringCalculatorInteractions(loggerMock.Object);

            calculator.Add("15");

            loggerMock.Verify(logger => logger.Log("15"));
        }

        [Fact]
        public void WebServiceIsCalledOnLoggerFailsure()
        {
            var loggerStub = new Mock<ILogger>();
            var calculator = new StringCalculator(loggerStub.Object);
            loggerStub.Setup(m => m.CreateChildLogger(It.IsAny<string>()))
                .Throws<CalculatorLoggerException>();

            calculator.Add("1");
        }
    }
}
