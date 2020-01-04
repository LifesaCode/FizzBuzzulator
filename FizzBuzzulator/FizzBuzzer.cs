using System;
using System.Text.RegularExpressions;

namespace FizzBuzzulator
{
    public class FizzBuzzer
    {
        double fizzValue = 3;
        double buzzValue = 5;

        public FizzBuzzer()
        {
            Console.WriteLine("\"Fizz\" = {0}    \"Buzz\" = {1}", fizzValue, buzzValue);
        }

        public void changeFizzBuzzValues()
        {
            string readData;
            bool invalidDivisor = true;

            while (invalidDivisor)
            {
                Console.WriteLine("Enter divisor for 'Fizz': ");
                readData = Console.ReadLine();
                invalidDivisor = isValidDivisor(readData);
               
                if(invalidDivisor)
                    fizzValue = Convert.ToDouble(readData);
            }

            invalidDivisor = true;

            while (invalidDivisor)
            {
                Console.WriteLine("Enter divisor for 'Buzz': ");
                readData = Console.ReadLine();
                invalidDivisor = isValidDivisor(readData);

                if (!invalidDivisor)
                    buzzValue = Convert.ToDouble(readData);
            }

            Console.WriteLine("\"Fizz\" = {0}    \"Buzz\" = {1}", fizzValue, buzzValue);
        }

        private bool isValidDivisor(string data)
        {
            if (Regex.IsMatch(data, "[^1-9]"))
            {
                Console.WriteLine("Divisors can only contain digits 1-9");
                return true;
            }
            else
                return false;
        }

        public String fizzBuzz(double value)
        {
            if ((value % fizzValue == 0) && (value % buzzValue == 0))
                return "FizzBuzz!";
            else if (value % fizzValue == 0)
                return "Fizz!";
            else if (value % buzzValue == 0)
                return "Buzz!";
            else
                return "";
        }

    }
}
