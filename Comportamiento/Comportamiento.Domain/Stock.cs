using System.Collections.Generic;

namespace Comportamiento.Domain
{
    public class Stock : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        public string Symbol { get; }
        private double _price;

        public Stock(string symbol, double price)
        {
            Symbol = symbol;
            _price = price;
        }

        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(Symbol, _price);
            }
        }
    }
}
