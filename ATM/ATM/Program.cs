using System;
using System.Collections.Generic;

namespace ATM
{
    public class Atm
    {
        decimal balance = 10000;                //잔액, default = 10,000원
        decimal deposit = 0;                    //입금
        decimal withdraw = 0;                   //출금
        public string account = "2564";         //계좌번호, default = 2564
        List<string> list = new List<string>(); //입출금내역 저장

        public void menu()
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
        //1.잔액조회
        public void inquireBalance()
        {
            Console.WriteLine("현재 잔액 : " + String.Format($"{balance:#,###}원"));
        }

        //2.입금하기
        public void inquireDeposit()
        {
            Console.Write("입금액 입력 : ");
            deposit = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("입금액 : " + String.Format($"{deposit:#,###}원"));
            balance = balance + deposit;
            Console.WriteLine("입금 후 잔액 : " + String.Format($"{balance:#,###}원"));
            list.Add(account + "계좌 / " + DateTime.Now + " / " + "입금(+) " + " / " + String.Format($"{deposit:#,###}원") + " / 현재잔액 : " + String.Format($"{balance:#,###}원"));
        }

        //3.출금하기
        public void inquireWithdraw()
        {
            Console.Write("출금액 입력 : ");
            withdraw = Convert.ToDecimal(Console.ReadLine());

            //잔액만큼 출금 가능
            if (withdraw > balance)
            {
                Console.WriteLine("잔액이 부족합니다.");
                Console.WriteLine("현재 잔액 : " + String.Format($"{balance:#,###}원"));
                return;
            }

            Console.WriteLine("출금액 : " + String.Format($"{withdraw:#,###}원"));
            balance = balance - withdraw;
            Console.WriteLine("출금 후 잔액 : " + String.Format($"{balance:#,###}원"));
            list.Add(account + "계좌 / " + DateTime.Now + " / " + "출금(-) " + " / " + String.Format($"{withdraw:#,###}원") + " / 현재잔액 : " + String.Format($"{balance:#,###}원"));
        }

        //4.입출금내역조회
        public void inquireHistory()
        {
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Program
    {
        enum MyEnum
        {
            e_balance = 1,
            e_deposit = 2,
            e_withdraw = 3,
            e_history = 4,
            e_exit = 0
        }

        static void Main(string[] args)
        {
            string yourAccount = string.Empty;
            int choice = 0;
            int Cnt = 0;

            Atm atm = new Atm();

            do
            {
                Cnt++;
                Console.Write("계좌를 입력하세요 : ");
                yourAccount = Console.ReadLine();

            } while (atm.account != yourAccount && Cnt < 3);
            if (Cnt >= 3)
            {
                Console.WriteLine("Bye~~ Bye~~");
            }
            else
            {
                do
                {
                    atm.menu();

                    //메뉴 선택
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case (int)MyEnum.e_balance:
                            atm.inquireBalance();
                            break;
                        case (int)MyEnum.e_deposit:
                            atm.inquireDeposit();
                            break;
                        case (int)MyEnum.e_withdraw:
                            atm.inquireWithdraw();
                            break;
                        case (int)MyEnum.e_history:
                            atm.inquireHistory();
                            break;
                        case (int)MyEnum.e_exit:
                            break;
                        default:
                            Console.WriteLine("1,2,3,4,0 중에 선택하세요");
                            break;
                    }
                } while (choice != 0);
            }
        }
    }
}
