using System;
using System.Text.RegularExpressions;

namespace FizzBuzzulator
{
    class Program
    {
        static void Main(string[] args)
        {
            double answer;

            Calculator calculator = new Calculator();
            FizzBuzzer fizzbuzzer = new FizzBuzzer();

            bool retry = true;

            while (retry){

                Console.Write("Enter 'f' to change fizzbuzz values, x to quit, or <enter> to continue ");
                string action = Console.ReadLine();
                if (action.Equals("x"))
                    return;

                if (action.Equals("f"))
                    fizzbuzzer.changeFizzBuzzValues();

                answer = calculator.useCalculator();
                if(Double.IsNaN(answer)) { }
                else
                    Console.WriteLine("Solution is: {0}  {1}", answer, fizzbuzzer.fizzBuzz(answer));
 
            }
        }
    }
}
