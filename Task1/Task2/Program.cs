using System;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = GenerateRandomArray(10, 1, 100);

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {GetSum(numbers)}");
        }

        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random r = new Random();
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
                arr[i] = r.Next(min, max + 1);
            return arr;
        }

        public static int GetSum(int[] a)
        {
            int sum = 0;
            foreach (int x in a)
                sum += x;
            return sum;
        }

        public static double GetAverage(int[] a)
        {
            if (a.Length == 0) return 0;
            return (double)GetSum(a) / a.Length;
        }

        public static int GetMin(int[] a)
        {
            if (a.Length == 0) throw new ArgumentException("Масив порожній");
            int min = a[0];
            foreach (int x in a)
                if (x < min) min = x;
            return min;
        }

        public static int GetMax(int[] a)
        {
            if (a.Length == 0) throw new ArgumentException("Масив порожній");
            int max = a[0];
            foreach (int x in a)
                if (x > max) max = x;
            return max;
        }
    }
}
