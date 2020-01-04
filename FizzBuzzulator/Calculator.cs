using System;
using System.Text.RegularExpressions;

namespace FizzBuzzulator
{
    class Calculator
    {
        public double useCalculator()
        {
            return calcAnswer(getOperand(), getOperation(), getOperand());
        }

        private double getOperand()
        {
            bool invalidEntry = true;
            double operand = 0;

            while (invalidEntry)
            {
                Console.Write("Operand: ");
                string readData = Console.ReadLine();                  

                if (Regex.IsMatch(readData, "[^0-9]"))
                    Console.WriteLine("Operands can only contain digits 0-9");
                else
                {
                    operand = Convert.ToDouble(readData);
                    invalidEntry = false;
                }
            }
            return operand;
        }

        private string getOperation()
        {
            bool invalidEntry = true;
            string operation = "";

            while (invalidEntry)
            {
                Console.Write("Operation: ");
                operation = Console.ReadLine();

                if (Regex.IsMatch(operation, "[^-+*/]"))
                    Console.WriteLine("Operations allowed are +, -, *, / ");
                else
                {
                    invalidEntry = false;
                }
            }
            return operation;
        }

        private double calcAnswer(double operand1, string operation, double operand2)
        {
            switch (operation)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2.Equals(0))
                    {
                        Console.WriteLine("Cannot divide by zero");
                        return Double.NaN;
                    }
                    else
                        return operand1 / operand2;         //+ (operand1 % operand2)
                default:
                    return Double.NaN;
            }
        }
    }
}
