using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers != "")
            {
                // create a variable for a running sum
                int sum = 0;

                // get a list of separators
                char[] separator = { ',', '\n' };

                // split into an array of strings
                var numbersArr = numbers.Split(separator);

                // parse the array of strings into ints
                foreach(var number in numbersArr)
                {
                    sum += int.Parse(number);
                }

                return sum;
            }
            return 0;
        }
    }
}
