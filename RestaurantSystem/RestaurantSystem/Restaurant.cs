using System;
using System.Collections.Generic;
using RestaurantApp.Interfaces;
using RestaurantApp.Orders;

namespace RestaurantApp.RestaurantLogic
{
    public class Restaurant
    {
        public List<IMenuItem> Menu { get; private set; } = new List<IMenuItem>();
        public List<Order> Orders { get; private set; } = new List<Order>();

        public void AddMenuItem(IMenuItem item)
        {
            Menu.Add(item);
        }

        public void ShowMenu()
        {
            Console.WriteLine("--- МЕНЮ РЕСТОРАНУ ---");
            int index = 1;
            foreach (var item in Menu)
            {
                Console.WriteLine($"{index}. {item.GetInfo()}");
                index++;
            }
            Console.WriteLine("-----------------------");
        }

        public Order CreateOrder(int id, int table)
        {
            var order = new Order(id, table);
            Orders.Add(order);
            Console.WriteLine($"Створено нове замовлення для столика №{table}");
            return order;
        }

        public Order FindOrder(int id)
        {
            return Orders.Find(o => o.Id == id);
        }

        public void ShowAllOrders()
        {
            Console.WriteLine("--- УСІ ЗАМОВЛЕННЯ ---");
            foreach (var order in Orders)
                order.Print();
        }
    }
}
