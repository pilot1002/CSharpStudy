using System;

namespace LIveCoding_01Calc
{
    class Program
    {
        static ConsoleKeyInfo keys;
        static string choiceOp = String.Empty;
        static double input1 = 0d;
        static double input2 = 0d;
        static double result = 0d;

        //입력된 숫자 횟수
        static int cnt = 0;

        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.Write("숫자를 입력하세요 --> ");
                    input1 = Convert.ToDouble(Console.ReadLine());

                    if (keys.Key.ToString() == "Escape")
                    {
                        input1 = 0;
                    }

                    //입력된 숫자가 첫번째이면, input2에 input1의 값을 복사
                    //나중에 "=" or "Enter"를 눌렀을때 반복계산을 위한 기준 값이 됨
                    if (cnt == 0)
                    {
                        input2 = input1;
                        Console.WriteLine($"input2 : input1 = {input2} : {input1}");
                    }

                    cnt++;
                    Console.WriteLine($"입력된 숫자 : {input1} <--- {cnt}번째 입력된 숫자");

                    Console.Write("연산자 입력 : (+) (-) (*) (/) 만 가능 :   ");
                    keys = Console.ReadKey();
                    Console.WriteLine($"\n입력된 키 : {keys.Key} or {keys.KeyChar}");

                    choiceOp = keys.KeyChar.ToString();

                    if (cnt > 0)
                    {
                        Console.WriteLine($"input2 : input1 = {input2} : {input1}");
                        Op();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("catch에 들어왔습니다.");
                    Console.WriteLine(keys.Key.ToString());
                    Console.WriteLine(choiceOp);
                    if (keys.Key.ToString() == "Enter" || choiceOp == "=")
                    {
                        Console.WriteLine("Enter 를 눌럿습니다.");
                    }
                    
                    else
                    {
                        Op();
                    }
                }
            }//while
        }//Main

        static void Op()
        {
            switch (choiceOp)
            {
                case "+":
                    Add();
                    break;
                case "-":
                    Sub();
                    break;
                case "*":
                    Mul();
                    break;
                case "/":
                    Div();
                    break;
                default:
                    Console.WriteLine("연산자만 입력 가능");
                    break;
            }
        }

        //덧셈
        static void Add()
        {
            Console.WriteLine("덧셈을 시작합니다.");
            result = result + input1;
            Console.WriteLine($"결과값은 ---------------------------> {result}");
        }

        //뺄셈
        static void Sub()
        {
            Console.WriteLine("뺄셈을 시작합니다.");
            result = result - input1;
            Console.WriteLine($"결과값은 ---------------------------> {result}");
        }

        //곱셈
        static void Mul()
        {
            Console.WriteLine("곱셈을 시작합니다.");
            result = result * input1;
            Console.WriteLine($"결과값은 ---------------------------> {result}");
        }

        //나눗셈
        static void Div()
        {
            Console.WriteLine("나눗셈을 시작합니다.");
            result = result / input1;
            Console.WriteLine($"결과값은 ---------------------------> {result}");
        }
    }
}


