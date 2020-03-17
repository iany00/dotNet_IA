using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    class InventoryData
    {
        public List<Car> LoadFordStoreInventory()
        {
            List<Car> fordInventory = new List<Car>();
            Producer fordProducer = new Producer("Ford Motors Company");

            Car fordFocus = new Car {
                Model       = "Ford Focus",
                Year        = 2015,
                Price       = 15000,
                Currency    = "Euro",
                Producer    = fordProducer,
                Available   = true,
                Reserved    = false,
                DeliverDate = DateTime.Now.AddDays(28)
            };
            fordInventory.Add(fordFocus);

            return fordInventory;
        }


        public List<Car> LoadScodaStoreInventory()
        {
            List<Car> scodaInventory = new List<Car>();
            Producer fordProducer = new Producer("Ford Motors Company");

            Car fordFocus = new Car
            {
                Model    = "Ford Focus",
                Year     = 2015,
                Price    = 14000,
                Currency = "Euro",
                Producer = fordProducer,
                Available = true,
                Reserved  = false,
                DeliverDate = DateTime.Now.AddDays(21)
            };

            scodaInventory.Add(fordFocus);

            Producer daciaProducer = new Producer("Dacia");
            Car Dacia = new Car
            {
                Model = "Dacia 1310",
                Year = 1999,
                Price = 1000,
                Currency = "Euro",
                Producer = daciaProducer,
                Available = true,
                Reserved = false,
                DeliverDate = DateTime.Now
            };

            scodaInventory.Add(Dacia);

            return scodaInventory;
        }


    }
}
