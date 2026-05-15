using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace ConsoleApp2
{
    internal class Program
    {

        private static void showArr(List<int> list)
        {
            foreach(int el in list)
            {
                Console.Write($"{el} " );
            } 
            Console.Write("\n");
        }

        private static void randArr(List<int> list, int leng)
        {
            Random rand = new Random();
            for (int i = 0; i < leng; i++) 
            { 
                list.Add(rand.Next(0, 100));
            }
        }

        private static void randMatrix(int M, int N, int[,] matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = rand.Next(0, 100); 
                }
            }
        }
        private static void showMatrix(int M, int N, int[,] matrix)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                } 
                Console.Write("\n");
            }
           
        }

        private static void SwapColumns(int[,] matrix, int column1, int column2)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int temp = matrix[i, column1];
                matrix[i, column1] = matrix[i, column2];
                matrix[i, column2] = temp;
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("\nЗадание №1\n");

            List<int> list = new List<int>() {1, 0, 2, 3, 0, 4, 5, 0, 6};

            showArr(list);

            for (int i = 0; i < list.Count; i++ )
            {
                int a = list.Count();

                if (i == 0)
                {
                    list.RemoveAll(x => x == 0);

                    while (list.Count != a)
                    {
                        list.Add(-1);
                    }
                }
            }
            showArr(list);

            Console.WriteLine("\nЗадание №2\n");

            List<int> list1 = new List<int>() { 1, 0, -2, 3, -4, 5, -6 };
            showArr(list1);
            
            list1.Sort();
            showArr(list1);

            Console.WriteLine("\nЗадание №3\n");

            List<int> list3 = new List<int>();
            randArr(list3, 20);
            
            Console.WriteLine("Массив: ");
            showArr(list3);

            Console.WriteLine("Введите любое число");
            int input = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Ваше число встречалось в массиве столько раз: {list3.Where(x => x == input).Count()}");


            Console.WriteLine("\nЗадание №4\n");

            
            int[,] array = new int[3, 3];

            Console.WriteLine("Изначальная матрица: ");
            randMatrix(3, 3, array);
            showMatrix(3, 3, array);
            
            Console.WriteLine("Выберите две колонны матрицы размером 3x3");
            int input1 = Convert.ToInt32(Console.ReadLine());
            int input2 = Convert.ToInt32(Console.ReadLine());

            try
            {
                SwapColumns(array, input1, input2);
            } 
            catch (IndexOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                SystemSounds.Exclamation.Play();
                Console.WriteLine("Ошибка, индекс за пределами границ!!!");
                Console.ResetColor();
                Environment.Exit(0);
            }
            
            Console.WriteLine("Матрица где поменяли колонны местами: ");
            showMatrix(3, 3, array);
        }
    }
}
