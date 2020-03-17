using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    interface IVehicle
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public Producer Producer { get; set; }
        void Print();
    }
}
