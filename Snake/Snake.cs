using System;
using System.Threading;
namespace Snake
{
    class program
    {
        static void  Main()
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 15;
            short[,] area = new short[30, 15];
            short[] direction = new short[450];
            byte[,] apple = new byte[30, 15];
            Random rnd = new Random();
            byte rx = 30;
            byte ry = 0;
            sbyte x = 0;
            sbyte y = 0;
            sbyte cx =0;
            sbyte cy =0;
            byte ax=0;
            byte ay=0;
            int score = 0;
            short rscore = 100;
            bool apple_ = false;
            short length = 5;
            short clenght = 0;
            short n = 0;
            bool clicking = true;
            bool game = true;
            byte record = 0;
            string key;
            Console.SetCursorPosition(64, 1);
            Console.WriteLine("Длина:");
            Console.SetCursorPosition(64, 2);
            Console.WriteLine(length);
            Console.SetCursorPosition(64, 3);
            Console.WriteLine("Счет:");
            Console.SetCursorPosition(64, 4);
            Console.WriteLine(score);
            while (ry < 16)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Write(rx, ry);
                ry++;
            }
            new Thread(() =>
            {
                while (clicking == true)
                {
                    key = Convert.ToString(Console.ReadKey(true).Key);
                    if (key == "UpArrow"&&record!=3)
                        record = 1;
                    else if (key == "RightArrow" && record != 4)
                        record = 2;
                    else if (key == "DownArrow" && record != 1)
                        record = 3;
                    else if (key == "LeftArrow" && record != 2)
                        record = 4;
                }
            }
            ).Start();
            while (true)
            {
                direction[n] = record;
                if (length == clenght)
                {
                    if (n >= length)
                    {
                        switch (direction[n - length])
                        {
                            case 1: cy--; break;
                            case 2: cx++; break;
                            case 3: cy++; break;
                            case 4: cx--; break;
                        }
                    }
                    else if (n < length)
                    {
                        switch (direction[n + 450 - length])
                        {
                            case 1: cy--; break;
                            case 2: cx++; break;
                            case 3: cy++; break;
                            case 4: cx--; break;
                        }
                    }
                    if (cx == -1)
                        cx = 29;
                    else if (cx == 30)
                        cx = 0;
                    else if (cy == -1)
                        cy = 14;
                    else if (cy == 15)
                        cy = 0;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Write(cx, cy);
                }
                else
                    clenght++;
                area[cx, cy] = 0;
                switch (direction[n])
                {
                    case 1: y--; break;
                    case 2: x++; break;
                    case 3: y++; break;
                    case 4: x--; break;
                }
                if (x == -1)
                    x = 29;
                else if (x == 30)
                    x = 0;
                else if (y == -1)
                    y = 14;
                else if (y == 15)
                    y = 0;
                if (area[x, y] == 1)
                {
                    clicking = false;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Write(x, y);
                    break;
                }
                else if (area[x, y] == 2)
                {
                    apple_ = false;
                    length++;
                    score += rscore;
                    rscore += 50;
                    Console.SetCursorPosition(64, 2);
                    Console.WriteLine(length);
                    Console.SetCursorPosition(64, 4);
                    Console.WriteLine(score);
                }
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Write(x, y);
                area[x, y] = 1;
                if (apple_ == false)
                {
                    do
                    {
                        ax = Convert.ToByte(rnd.Next(28));
                        ay = Convert.ToByte(rnd.Next(14));
                    }
                    while (area[ax, ay] == 1);
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Write(ax, ay);
                    area[ax, ay] = 2;
                    apple_ = true;
                }
                n++;
                if (n == 450)
                    n = 0;
                Thread.Sleep(150);
                if (length == 450)
                {
                    clicking = false;
                    break;
                }
            }
                Thread.Sleep(2000);
                while (area[x, y] != 0)
                {
                    switch (direction[n])
                    {
                        case 1: y++; break;
                        case 2: x--; break;
                        case 3: y--; break;
                        case 4: x++; break;
                    }
                if (x == -1)
                    x = 29;
                else if (x == 30)
                    x = 0;
                else if (y == -1)
                    y = 14;
                else if (y == 15)
                    y = 0;
                Console.BackgroundColor = ConsoleColor.Black;
                    Write(x, y);
                    n--;
                    if (n == -1)
                        n = 449;
                    Thread.Sleep(50);
                }
                Console.ReadKey();
        }
        private static void Write(short x,short y)
        {
            Console.SetCursorPosition(x * 2, y);
            Console.Write(' ');
            Console.SetCursorPosition(x * 2 + 1, y);
            Console.Write(' ');
        }
    }
}