using System;

class Task1
{
    public static void Run()
    {
        Console.WriteLine("Задача №1");

        Console.Write("Введите длина прямоугольника А: ");
        ushort a = Convert.ToUInt16(Console.ReadLine());

        Console.Write("Введите ширину прямоугольника B: ");
        ushort b = Convert.ToUInt16(Console.ReadLine());

        Console.Write("Введите ширину прямоугольника С: ");
        ushort c = Convert.ToUInt16(Console.ReadLine());

        if (c > a || c > b)
        {
            Console.WriteLine($"В прямоугольнике {a}x{b} " +
                $"нельзя разместить ни одного квадрата со стороной {c}");
        }
        else
        {
            ushort countX = (ushort)(a / c);
            ushort countY = (ushort)(b / c);
            ushort totalCubes = (ushort)(countX * countY);

            uint reArea = (uint)(a * b);
            uint cuArea = (uint)(totalCubes * (c * c));
            uint frArea = (uint)(reArea - cuArea);

            Console.WriteLine($"Кол-во квадратов: {totalCubes}");
            Console.WriteLine($"Площадь незанятой части: {frArea}");
        }
    }
}

class Task2
{
    public static void Run()
    {
        Console.WriteLine("Задача 2");
        
        Console.Write("Введите ставку Proc (0 < Proc < 25): ");
        decimal proc = Convert.ToDecimal(Console.ReadLine().Replace('.', ','));

        decimal s = 10000.0M;
        uint k = 0;

        while (s <= 11000)
        {
            s += s * (proc / 100);
            k++;
        }

        Console.WriteLine($"Кол-во месяцев К: {k}");
        Console.WriteLine($"Итоговый размер вклада S: {Math.Round(s, 2)} руб.");
    }
}

class Task3
{
    public static void Run()
    {
        Console.WriteLine("Задача 3");
        Console.Write("Введите целое положительное число А: ");
        uint a = Convert.ToUInt32(Console.ReadLine());

        Console.Write("Введите целое положительное число В (должно быть больше А): ");
        uint b = Convert.ToUInt32(Console.ReadLine());

        if (a >= b)
        {
            Console.WriteLine("число А должно быть строго меньше В!");
            return;
        }

        Console.WriteLine("\n Результат: ");
        for (uint i = 0; i < a; i++)
        {
            for (uint j = 0; j < b; j++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}

class Task4
{
    public static void Run()
    {
        Console.WriteLine("Задача 4");
        Console.Write("Введите целое число N больше 0: ");
        uint n = Convert.ToUInt32(Console.ReadLine());
        uint reverseNum = 0;
        uint temp = n;

        while (temp > 0)
        {
            uint zapomnil = temp % 10;
            reverseNum = (reverseNum * 10) + zapomnil;
            temp /= 10;
        }

        Console.WriteLine($"Число {n} справа налево: {reverseNum}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.WriteLine("Выберите задание для запуска:");
            Console.WriteLine("1 - Задача 1 ");
            Console.WriteLine("2 - Задача 2 ");
            Console.WriteLine("3 - Задача 3 ");
            Console.WriteLine("4 - Задача 4 ");
            Console.WriteLine("0 - Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1.Run();
                    break;
                case "2":
                    Task2.Run();
                    break;
                case "3":
                    Task3.Run();
                    break;
                case "4":
                    Task4.Run();
                    break;
                case "0":
                    keepRunning = false;
                    Console.WriteLine("Программа завершена.");
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите номер от 0 до 4.");
                    break;
            }
        }
    }
}