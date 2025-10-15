using System;

namespace Task4
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Введіть сторони трикутника:");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            if (!IsValidTriangle(a, b, c))
            {
                Console.WriteLine("Неможливо утворити трикутник із таких сторін.");
                return;
            }

            double perimeter = GetPerimeter(a, b, c);
            double area = GetArea(a, b, c);
            string type = GetTriangleType(a, b, c);

            Console.WriteLine($"\nПериметр: {perimeter:F2}");
            Console.WriteLine($"Площа: {area:F2}");
            Console.WriteLine($"Тип трикутника: {type}");
        }

        public static bool IsValidTriangle(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 &&
                   a + b > c && a + c > b && b + c > a;
        }
        public static double GetPerimeter(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("Невірні сторони трикутника");

            return a + b + c;
        }
        public static double GetArea(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("Невірні сторони трикутника");

            double p = GetPerimeter(a, b, c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public static string GetTriangleType(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
                throw new ArgumentException("Невірні сторони трикутника");

            const double EPS = 0.0001;

            if (Math.Abs(a - b) < EPS && Math.Abs(b - c) < EPS)
                return "рівносторонній";

            if (Math.Abs(a - b) < EPS || Math.Abs(a - c) < EPS || Math.Abs(b - c) < EPS)
                return "рівнобедрений";

            double a2 = a * a, b2 = b * b, c2 = c * c;
            if (Math.Abs(a2 + b2 - c2) < EPS ||
                Math.Abs(a2 + c2 - b2) < EPS ||
                Math.Abs(b2 + c2 - a2) < EPS)
                return "прямокутний";

            return "довільний";
        }
    }
}
