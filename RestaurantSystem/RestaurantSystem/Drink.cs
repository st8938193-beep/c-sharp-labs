using RestaurantApp.Interfaces;

namespace RestaurantApp.Menu
{
    public class Drink : IMenuItem
    {
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Volume { get; private set; }
        public bool IsAlcohol { get; private set; }

        public Drink(string name, double price, int volume, bool alcohol)
        {
            Name = name;
            Price = price;
            Volume = volume;
            IsAlcohol = alcohol;
        }

        public string GetInfo()
        {
            string type = IsAlcohol ? "алкогольний" : "без алкоголю";
            return $"{Name} ({Volume} мл, {type}) - {Price} грн";
        }
    }
}
