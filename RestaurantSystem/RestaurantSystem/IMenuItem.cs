namespace RestaurantApp.Interfaces
{
    public interface IMenuItem
    {
        string Name { get; }
        double Price { get; }
        string GetInfo();
    }
}
