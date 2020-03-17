using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    class Producer : IProducer
    {
        public string Name { get; set; }

        public Producer(string name)
        {
            this.Name = name;
        }
    }
}
