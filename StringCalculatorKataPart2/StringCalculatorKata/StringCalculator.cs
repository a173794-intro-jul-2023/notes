using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private readonly ILogger _logger;
        private readonly object _webService;

        public StringCalculator(ILogger logger)
        {
            _logger = logger;
        }

        public int Add(string numbers)
        {
            int result = 0;
            if (numbers != "") 
            { 
                return numbers.Split(',')
                    .Select(int.Parse).Sum();
            }

            try
            {
                _logger.Log(result.ToString());
            } catch (CalculatorLoggerException)
            {
                object value = _webService.NotifyOfLoggerFailure("UH OH!");
            }
            return result;
        }
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            // logging logic would go here
            Console.WriteLine(message);
        }
    }

}
