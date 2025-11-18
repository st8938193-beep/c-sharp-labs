using System;
using RestaurantApp.Menu;
using RestaurantApp.Enums;
using RestaurantApp.RestaurantLogic;
using RestaurantApp.Interfaces;

namespace RestaurantApp
{
    public class Program
    {
        static Restaurant restaurant = new Restaurant();
        static int orderCounter = 100;

        static void Main(string[] args)
        {
            SeedMenu();
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== ГОЛОВНЕ МЕНЮ ===");
                Console.WriteLine("1. Показати меню");
                Console.WriteLine("2. Створити замовлення");
                Console.WriteLine("3. Додати позицію в замовлення");
                Console.WriteLine("4. Змінити статус замовлення");
                Console.WriteLine("5. Показати всі замовлення");
                Console.WriteLine("6. Пошук замовлення");
                Console.WriteLine("0. Вихід");

                Console.Write("Ваш вибір: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": restaurant.ShowMenu(); break;
                    case "2": CreateOrder(); break;
                    case "3": AddItemToOrder(); break;
                    case "4": ChangeOrderStatus(); break;
                    case "5": restaurant.ShowAllOrders(); break;
                    case "6": SearchOrder(); break;
                    case "0": return;
                    default: Console.WriteLine("Невірний вибір!"); break;
                }
            }
        }

        // Створення меню
        static void SeedMenu()
        {
            restaurant.AddMenuItem(new Dish("Борщ", 120, "Перше"));
            restaurant.AddMenuItem(new Drink("Кава", 60, 200, false));
            restaurant.AddMenuItem(new Drink("Сік апельсиновий", 70, 250, false));
            restaurant.AddMenuItem(new Drink("Кока-кола", 50, 330, false));
            restaurant.AddMenuItem(new Dish("Вареники", 120, "Друге"));
            restaurant.AddMenuItem(new Dish("Деруни", 135, "Друге"));
        }

        // Створення замовлення
        static void CreateOrder()
        {
            Console.Write("Введіть номер столика: ");
            int table = int.Parse(Console.ReadLine());

            orderCounter++;
            restaurant.CreateOrder(orderCounter, table);
            Console.WriteLine($"Нове замовлення створено. ID = {orderCounter}");
        }

        // Додати позицію до замовлення
        static void AddItemToOrder()
        {
            Console.Write("Введіть ID замовлення: ");
            int id = int.Parse(Console.ReadLine());

            var order = restaurant.FindOrder(id);
            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдене!");
                return;
            }

            restaurant.ShowMenu();
            Console.Write("Введіть номер позиції з меню: ");
            int index = int.Parse(Console.ReadLine());

            if (index < 1 || index > restaurant.Menu.Count)
            {
                Console.WriteLine("Невірний номер позиції!");
                return;
            }

            IMenuItem item = restaurant.Menu[index - 1];
            order.AddItem(item);
            Console.WriteLine($"Поточна сума: {order.GetTotal()} грн");
        }

        // Змінити статус
        static void ChangeOrderStatus()
        {
            Console.Write("Введіть ID замовлення: ");
            int id = int.Parse(Console.ReadLine());

            var order = restaurant.FindOrder(id);
            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдене!");
                return;
            }

            Console.WriteLine("Оберіть статус:");
            Console.WriteLine("1. New");
            Console.WriteLine("2. InProgress");
            Console.WriteLine("3. Ready");
            Console.WriteLine("4. Paid");

            Console.Write("Ваш вибір: ");
            string s = Console.ReadLine();

            switch (s)
            {
                case "1": order.SetStatus(OrderStatus.New); break;
                case "2": order.SetStatus(OrderStatus.InProgress); break;
                case "3": order.SetStatus(OrderStatus.Ready); break;
                case "4": order.SetStatus(OrderStatus.Paid); break;
                default: Console.WriteLine("Невірний статус!"); break;
            }
        }
        // Пошук замовлення
        static void SearchOrder()
        {
            Console.Write("Введіть ID замовлення: ");
            int id = int.Parse(Console.ReadLine());

            var order = restaurant.FindOrder(id);
            if (order == null)
            {
                Console.WriteLine("Замовлення не знайдене!");
                return;
            }

            Console.WriteLine("--- ЗНАЙДЕНО ---");
            order.Print();
        }
    }
}
