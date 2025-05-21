using System;

namespace Task13_1
{
    internal class Program
    {
        // Делегат
        public delegate int Transformer(int number);

        //Метод
        public static int[] Transform(int[] numbers, Transformer transformer)
        {
            int[] result = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = transformer(numbers[i]);
            }
            return result;
        }

        static void Main(string[] args)
        {
            //Создание массива
            var numbers = new int[] { 1, -2, 3, -4, 5 };

            //Удвоение всех чисел
            int[] doubler = Transform(numbers, n => n * 2);
            Console.WriteLine(string.Join(",", doubler));

            //Возведение в квадрат
            int[] power2 = Transform(numbers, n => Convert.ToInt32(Math.Pow(Convert.ToDouble(n),2.0)));
            Console.WriteLine(string.Join(",", power2));

            //Замена чисел на их модули
            int[] abs = Transform(numbers, n => Math.Abs(n));
            Console.WriteLine(string.Join(",", abs));

            Console.ReadKey();
        }
    }
}

