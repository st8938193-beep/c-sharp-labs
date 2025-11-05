using System;

namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Введіть вік: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine(ClassifyAge(age));
            }
            else
            {
                Console.WriteLine("Некоректне введення.");
            }
        }
        public static string ClassifyAge(int age)
        {
            if (age < 0 || age > 120)
                return "Нереальний вік";
            if (age <= 11)
                return "Ви дитина";
            if (age >= 12 && age <= 17)
                return "Підліток";
            if (age >= 18 && age <= 59)
                return "Дорослий";
            return "Пенсіонер";
        }
    }
}
