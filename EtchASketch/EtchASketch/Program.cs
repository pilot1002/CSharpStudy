using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtchASketch
{
    class Program
    {
        public void Sketch()
        {
            Stack<Cell> path;           // 제너릭 변수 선언
            path = new Stack<Cell>();   // 제너릭 객체 인스턴스 생성
            Cell currentPosition;
            ConsoleKeyInfo key;

            do
            {
                key = Move();
                switch (key.Key)
                {
                    case ConsoleKey.Z:
                        if (path.Count >= 1)
                        {
                            currentPosition = path.Pop();
                            Console.SetCursorPosition(currentPosition.X, currentPosition.Y);
                            Undo();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.RightArrow:
                        currentPosition = new Cell(Console.CursorLeft, Console.CursorTop);
                        path.Push(currentPosition);
                        break;
                    default:
                        Console.Beep();
                        break;
                }
            }
            while (key.Key != ConsoleKey.X);
        }

        public struct Cell
        {
            public int X { get; }
            public int Y { get; }
            public Cell(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
