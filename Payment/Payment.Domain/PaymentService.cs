using System;

namespace Payment.Domain
{
    public class PaymentService
    {
        public bool ProcessPayment(int SelectedPaymentType, double Amount)
        {
            PaymentContext context = new PaymentContext();
            if (SelectedPaymentType == (int)PaymentType.CreditCard)
            {
                context.SetPaymentStrategy(new CreditCardPaymentStrategy());
            }
            else if (SelectedPaymentType == (int)PaymentType.DebitCard)
            {
                context.SetPaymentStrategy(new DebitCardPaymentStrategy());
            }
            else if (SelectedPaymentType == (int)PaymentType.Cash)
            {
                context.SetPaymentStrategy(new CashPaymentStrategy());
            }
            else
            {
                throw new ArgumentException("You Select an Invalid Payment Option");
            }
            return context.Pay(Amount);
        }
    }
    public enum PaymentType
    {
        CreditCard = 1,
        DebitCard = 2,
        Cash = 3,
    }
}
