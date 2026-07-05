namespace Comportamiento.Domain
{
    public class Trader : IObserver
    {
        public string Name { get; }
        public string LastUpdatedStock { get; private set; } = "";
        public double LastUpdatedPrice { get; private set; }

        public Trader(string name)
        {
            Name = name;
        }

        public void Update(string stockSymbol, double price)
        {
            LastUpdatedStock = stockSymbol;
            LastUpdatedPrice = price;
        }
    }
}
