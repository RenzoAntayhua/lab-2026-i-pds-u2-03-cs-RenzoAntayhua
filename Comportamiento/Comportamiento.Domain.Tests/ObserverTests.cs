using NUnit.Framework;
using Comportamiento.Domain;

namespace Comportamiento.Domain.Tests
{
    public class ObserverTests
    {
        [Test]
        public void GivenStockAndTrader_WhenPriceChanges_TraderIsNotified()
        {
            var googleStock = new Stock("GOOG", 150.00);
            var trader = new Trader("Alice");

            googleStock.Attach(trader);

            googleStock.Price = 155.50;

            Assert.That(trader.LastUpdatedStock, Is.EqualTo("GOOG"));
            Assert.That(trader.LastUpdatedPrice, Is.EqualTo(155.50));
        }

        [Test]
        public void GivenDetachedTrader_WhenPriceChanges_TraderIsNotNotified()
        {
            var googleStock = new Stock("GOOG", 150.00);
            var trader = new Trader("Alice");

            googleStock.Attach(trader);
            googleStock.Detach(trader);

            googleStock.Price = 160.00;

            Assert.That(trader.LastUpdatedStock, Is.Not.EqualTo("GOOG"));
            Assert.That(trader.LastUpdatedPrice, Is.Not.EqualTo(160.00));
        }
    }
}
