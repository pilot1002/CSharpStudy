using System;
using System.Linq;

namespace LIveCoding_01Calc
{
    class Program
    {
        private static readonly string[] operations = { "+", "-", "*", "/" };

        static void Main(string[] args)
        {
            double result = 0;
            double firstNumber = SetNumber("첫번째 숫자 : ");
            double secondNumber = SetNumber("두번째 숫자 : ");

            string stringOperation = SetOperation("연산자 선택 : + (a), - (s), * (m), / (d) : ");

            switch (stringOperation)
            {
                case "+":
                case "a":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                case "s":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                case "m":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                case "d":
                    result = firstNumber / secondNumber;
                    break;
            }
            Console.WriteLine($"결과 : {firstNumber} {stringOperation} {secondNumber} = {result}");
        }

        private static double SetNumber(string outputText)
        {
            double parse;
            Console.Write(outputText);
            string tempInput = Console.ReadLine();
            while (!double.TryParse(tempInput, out parse))
            {
                Console.WriteLine("숫자만 입력 가능");
                Console.Write(outputText);
                tempInput = Console.ReadLine();
            }
            return double.Parse(tempInput);
        }

        private static bool IsValidOperation(string input)
        {
            return operations.Contains(input);
        }

        private static string SetOperation(string outputText)
        {
            Console.Write(outputText);
            string tempInput = Console.ReadLine();
            while (!IsValidOperation(tempInput))
            {
                Console.WriteLine("사칙연산만 가능");
                Console.Write(outputText);
                tempInput = Console.ReadLine();
            }
            return tempInput;
        }
    }
}


