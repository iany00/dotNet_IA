using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop
{
    internal class MilkDecorator : CondimentDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
            _name = "Milk";
            _price = 1;
        }
    }
}
