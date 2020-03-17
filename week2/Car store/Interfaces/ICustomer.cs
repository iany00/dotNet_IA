using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    interface ICustomer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        void Print();
    }
}
