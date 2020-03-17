using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    class Car : IVehicle
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public Producer Producer { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public bool Reserved { get; set; }
        public bool Available { get; set; }
        public DateTime DeliverDate { get; set; }

        public void Print()
        {
            DataWriteManager dataWriteManager = new DataWriteManager();

            dataWriteManager.WriteLine($"Model: {this.Model}");
            dataWriteManager.WriteLine($"Year: {this.Year}");
            dataWriteManager.WriteLine($"Producer: {this.Producer.Name}");
            dataWriteManager.WriteLine($"Price: {this.Price} {this.Currency}");
            
        }

        internal void MakeCarNotAvailable()
        {
            this.Available = false;
        }
    }
}
