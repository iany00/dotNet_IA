using System;

namespace CoffeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffee = new ChocolateDecorator(new Espresso());
            //...
        }
    }
}
