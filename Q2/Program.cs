using System;

namespace Q2
{

    class Payment : ITax
    {

        public event UpdateAmountHandler AmountChanged;

        public float amount { get; set; }

        public Payment()
        {

        }

        public float Amount { 
            get => amount;
            set
            {
                float old = amount;
                amount = value;
                if (AmountChanged != null)
                {
                    AmountChanged(old, amount);
                }
            }
        }

        public float ComputeTax()
        {
            return Amount * 10 / 100 ;
        }
    }

    public delegate void UpdateAmountHandler(float oldValue, float newValue);

    class Program
    {
        static void Main(string[] args)
        {
            Payment payment = new Payment() { amount = 1000 };
            payment.AmountChanged += notifyAmountChanged; // your handling function
            payment.Amount = 990;
            Console.WriteLine("Tax:" +payment.ComputeTax());

        }

        private static void notifyAmountChanged(float oldValue, float newValue)
        {
            Console.WriteLine($"Amount changed - old value: {oldValue}, new value: {newValue}"); ;
        }
    }
}
