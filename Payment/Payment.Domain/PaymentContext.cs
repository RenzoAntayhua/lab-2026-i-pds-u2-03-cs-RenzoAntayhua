namespace Payment.Domain
{
    public class PaymentContext
    {
        private IPaymentStrategy? PaymentStrategy;
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            PaymentStrategy = strategy;
        }
        public bool Pay(double amount)
        {
            if (PaymentStrategy == null) return false;
            return PaymentStrategy.Pay(amount);
        }
    }
}
