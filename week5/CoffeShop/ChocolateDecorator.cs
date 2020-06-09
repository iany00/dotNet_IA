using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop
{
    class ChocolateDecorator : CondimentDecorator
    {
        public ChocolateDecorator(ICoffee coffee) : base(coffee)
        {
            _name = "Chocolate";
            _price = 1.5;
        }
    }
}
