using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    class Customer : ICustomer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
        public int VCC { get; set; }

        public void Print()
        {
            DataWriteManager dataWriteManager = new DataWriteManager();
            dataWriteManager.WriteLine($"Name: {this.Name}");
            dataWriteManager.WriteLine($"Age: {this.Age}");
        }
    }
}
