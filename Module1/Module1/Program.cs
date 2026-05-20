using System;
using System.Globalization;

namespace DateAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        //Задание 1
        Console.WriteLine("Введите число в диапозоне от 1 до 100");
        byte userInputByte = Convert.ToByte(Console.ReadLine());

        if (userInputByte < 1 || userInputByte > 100)
        {
            Console.WriteLine("Введённое вами число больше или меньше указанного диапозона");
            Environment.Exit(0);
        } 
        else
        {   
            if (userInputByte % 3 == 0 & userInputByte % 5 == 0)
            {
                Console.WriteLine("Fizz Buzz");
            }
            else if  (userInputByte % 5 == 0)
            {
                Console.WriteLine("Buzz");
            } 
            else if (userInputByte % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else
            {
                Console.WriteLine(userInputByte);
            }
        }

        //Задание 2
        Console.WriteLine("Введите любое число в качестве основного числа:");
        int userInputeNum = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите любое число в качестве процента:");
        int userInputeProc = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"{userInputeProc}% от числа: {userInputeNum} = " +
            $"{userInputeNum / 100 * userInputeProc}");

        //Задание 3
        Console.WriteLine("Введите 4 любых числа:");
        byte userIpnut1 = Convert.ToByte(Console.Read());
        byte userIpnut2 = Convert.ToByte(Console.Read());
        byte userIpnut3 = Convert.ToByte(Console.Read());
        byte userIpnut4 = Convert.ToByte(Console.Read());

        string CombinedNum = $"{userIpnut1}{userIpnut2}{userIpnut3}{userIpnut4}";
        int res = int.Parse(CombinedNum);

        Console.WriteLine($"Итоговое число: {res}");

        //Задание 4
        string number = GetValidSixDigitNumber();

        (int pos1, int pos2) = GetValidPositions();

        string result = SwapCharacters(number, pos1, pos2);

        Console.WriteLine($"\nРезультат: {result}");

        //Задание 5
        Console.OutputEncoding = System.Text.Encoding.UTF8;
     
        Console.Write("Введите дату в формате ДД.ММ.ГГГГ (например, 22.12.2021): ");
        string input = Console.ReadLine();

        if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            string season = GetSeason(parsedDate.Month);

            string dayOfWeek = parsedDate.DayOfWeek.ToString();

            Console.WriteLine($"\nРезультат: {season} {dayOfWeek}");
        }
        else
        {
            Console.WriteLine("Ошибка: Неверный формат даты. Пожалуйста, используйте формат ДД.ММ.ГГГГ.");
        }

        //Задание №6

        Console.Write("Введите значение температуры: ");
        if (!double.TryParse(Console.ReadLine(), out double inputTemp))
        {
            Console.WriteLine("Ошибка: Введено некорректное число.");
        }
        else
        {
            Console.WriteLine("Выберите:");
            Console.WriteLine("1 - Из Цельсия в Фаренгейт (°C -> °F)");
            Console.WriteLine("2 - Из Фаренгейта в Цельсий (°F -> °C)");
            Console.Write("Ваш выбор (1 или 2): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    double toFa = CelToFa(inputTemp);
                    Console.WriteLine($"{inputTemp}°C = {toFa:F2}°F");
                    break;

                case "2":
                    double toCel = FaToCel(inputTemp);
                    Console.WriteLine($"{inputTemp}°F = {toCel:F2}°C");
                    break;

                default:
                    Console.WriteLine("Такого варианта нет");
                    break;
            }
        }

        static string GetValidSixDigitNumber()
        {
            while (true)
            {
                Console.Write("Введите шестизначное число: ");
                string input = Console.ReadLine();

                if (input.Length == 6 && long.TryParse(input, out _))
                {
                    return input;
                }

                Console.WriteLine("Ошибка: введённое значение должно состоять ровно из 6 цифр.");
            }
        }

        //Функции
        static (int, int) GetValidPositions()
        {
            while (true)
            {
                Console.Write("Введите два номера разрядов для обмена (от 1 до 6) через пробел: ");
                string[] parts = Console.ReadLine().Split(' ');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int p1) &&
                    int.TryParse(parts[1], out int p2))
                {
                    if (p1 >= 1 && p1 <= 6 && p2 >= 1 && p2 <= 6)
                    {
                        return (p1, p2);
                    }
                }

                Console.WriteLine("Ошибка: нужно ввести два числа в диапазоне от 1 до 6. Попробуйте снова.");
            }
        }

        static string SwapCharacters(string str, int position1, int position2)
        {
            char[] array = str.ToCharArray();

            int index1 = position1 - 1;
            int index2 = position2 - 1;

            char temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;

            return new string(array);
        }

        static string GetSeason(int month)
        {
            return month switch
            {
                12 or 1 or 2 => "Winter",
                3 or 4 or 5 => "Spring",
                6 or 7 or 8 => "Summer",
                9 or 10 or 11 => "Autumn",
                _ => throw new ArgumentOutOfRangeException(nameof(month), "Недопустимый номер месяца.")
            };
        }

        static double CelToFa(double celsius)
        {
            return celsius * 1.8 + 32;
        }

        static double FaToCel(double fahrenheit)
        {
            return (fahrenheit - 32) / 1.8;
        }

    }
}