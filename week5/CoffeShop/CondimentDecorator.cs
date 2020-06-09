using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop
{
    public abstract class CondimentDecorator : ICoffee
    {
        ICoffee _coffee;

        protected string _name = "undefined";
        protected double _price = 0;

        public CondimentDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public string Description()
        {
            return string.Format("{0}, {1}", _coffee.Description(), _name);
        }

        public double Price()
        {
            return _coffee.Price() + _price;
        }
    }
}
