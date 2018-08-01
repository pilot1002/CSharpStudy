using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static decimal balance = 10000;
        static decimal deposit = 0;
        static decimal withdraw = 0;
        static List<string> lt = new List<string>();
        static string account = "2564";

        public static void menu()
        {
            Console.WriteLine();
            Console.WriteLine("메뉴를 선택하세요");
            Console.WriteLine("===============");
            Console.WriteLine("1.잔액조회");
            Console.WriteLine("2.입금하기");
            Console.WriteLine("3.출금하기");
            Console.WriteLine("4.입출금내역조회");
            Console.WriteLine("0.종료");
            Console.WriteLine("===============");
        }
        enum MyEnum
        {
            e_balance = 1,
            e_deposit = 2,
            e_withdraw = 3,
            e_history = 4,
            e_exit = 0
        }

        public static void inquireBalance()
        {
            Console.WriteLine("현재 잔액 : " + balance);
        }

        public static void inquireDeposit()
        {
            Console.Write("입금액 입력 : ");
            deposit = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("입금액 : " + deposit);
            balance = balance + deposit;
            Console.WriteLine("입금 후 잔액 : " + balance);
            lt.Add(account + " / " + DateTime.Now + " / " + "입금(+) " + " / " + deposit + " / 잔액 : " + balance);
        }

        public static void inquireWithdraw()
        {
            Console.Write("출금액 입력 : ");
            withdraw = Convert.ToDecimal(Console.ReadLine());

            //잔액만큼 출금 가능
            if(withdraw > balance)
            {
                Console.WriteLine("현재 잔액 : " + balance);
                Console.WriteLine("잔액이 부족합니다.");
                return;
            }

            Console.WriteLine("출금액 : " + withdraw);
            balance = balance - withdraw;
            Console.WriteLine("출금 후 잔액 : " + balance);
            lt.Add(account + " / " + DateTime.Now + " / " + "출금(-) " +" / " + withdraw + " / 잔액 : " + balance);
        }

        public static void inquireHistory()
        {
            foreach (var item in lt)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            string yourAccount = string.Empty;
            int choice = 0;
            int Cnt = 0;

            do
            {
                Cnt++;
                Console.Write("계좌를 입력하세요 : ");
                yourAccount = Console.ReadLine();

            } while (account != yourAccount && Cnt < 3);
            if (Cnt >= 3)
            {
                Console.WriteLine("Bye~~");
            }
            else
            {
                do
                {
                    menu();
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case (int)MyEnum.e_balance:
                            inquireBalance();
                            break;
                        case (int)MyEnum.e_deposit:
                            inquireDeposit();
                            break;
                        case (int)MyEnum.e_withdraw:
                            inquireWithdraw();
                            break;
                        case (int)MyEnum.e_history:
                            inquireHistory();
                            break;
                        case (int)MyEnum.e_exit:
                            break;
                        default:
                            Console.WriteLine("1,2,3,4,0 중에 선택해라");
                            break;
                    }
                } while (choice != (int)MyEnum.e_exit);
            }
        }
    }
}
