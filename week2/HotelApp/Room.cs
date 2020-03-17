using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    class Room
    {
        public string Name { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public Rate Rate { get; set; }

        public void Print()
        {
            Console.WriteLine($"Room : {this.Name} - (Adults: {this.Adults} - Children: {this.Children})");

            Rate.Print();
            Console.WriteLine("\n");
        }

    }
}
