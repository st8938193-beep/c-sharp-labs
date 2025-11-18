using System;
using System.Collections.Generic;
using RestaurantApp.Enums;
using RestaurantApp.Interfaces;

namespace RestaurantApp.Orders
{
    public class Order
    {
        private List<IMenuItem> items = new List<IMenuItem>();

        public int Id { get; private set; }
        public int TableNumber { get; private set; }
        public OrderStatus Status { get; private set; }

        public Order(int id, int table)
        {
            Id = id;
            TableNumber = table;
            Status = OrderStatus.New;
        }

        public void AddItem(IMenuItem item)
        {
            items.Add(item);
            Console.WriteLine($"Додано позицію: {item.Name}");
        }

        public void RemoveItem(string name)
        {
            items.RemoveAll(i => i.Name == name);
        }

        public double GetTotal()
        {
            double sum = 0;
            foreach (var i in items)
                sum += i.Price;
            return sum;
        }

        public void SetStatus(OrderStatus status)
        {
            Status = status;
            Console.WriteLine($"> Змінено статус: {status}");
        }

        public void Print()
        {
            Console.WriteLine($"ID: {Id} | Стіл: {TableNumber} | Статус: {Status} | Сума: {GetTotal()} грн");
        }
    }
}
