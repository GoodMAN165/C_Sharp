using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание №3");

        int[] origArr = {1, 2, 6, -1, 88, 7, 6 };
        int[] filtArr = {6, 88, 7};

        Console.WriteLine("Оригинальный массив: " + string.Join(" ", origArr));
        Console.WriteLine("Массив для фильтрации: " + string.Join(" ", filtArr));

        int[] res = FilterArray(origArr, filtArr);

        Console.WriteLine("Результат работы метода:  " + string.Join(" ", res));
    }

    public static int[] FilterArray(int[] original, int[] filter)
    {
        if (original == null) return Array.Empty<int>();
        if (filter == null || filter.Length == 0) return original;

        HashSet<int> filterSet = new HashSet<int>(filter);

        return original.Where(element => !filterSet.Contains(element)).ToArray();
    }
}
