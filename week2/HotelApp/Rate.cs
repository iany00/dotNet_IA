using System;

namespace Hotel
{
    class Rate
    {        
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public void Print()
        {
            Console.WriteLine($"Rate: Amount per day: {this.Amount} {this.Currency}");
        } 

    }
}
