namespace Task1
{

    public class Program
    {
        public static void Main()
        {
            Console.Write("Введіть число: ");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMessage(number));
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static string GetMessage(int number)
        {
            if (IsEven(number))
                return "Двері відкриваються!";
            else
                return "Двері зачинені...";
        }
    }
}