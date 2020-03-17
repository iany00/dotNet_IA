using Car_store.Log;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Car_store
{
    [Flags]
    enum LogLevel { INFO, DEBUG, WARNING, ERROR, FATAL };
    static class WriteDestination
    {
        public enum Type { Console, File };
        public static Type destination { get; set; }
    }

    class Program
    {
       static void Main(string[] args)
        {
            // Data write destination options
            Console.WriteLine("Type\n 0 if you want to see data writen in console \n 1 if you want to see that in Log/LogFile.log");
            int writeDestination;
            if(int.TryParse(Console.ReadLine(), out writeDestination))
            {
                WriteDestination.destination = (WriteDestination.Type)writeDestination;
            } else
            {
                Console.WriteLine("Invalid value!");
                Environment.Exit(1);
            }
            DataWriteManager dataWriteManager = new DataWriteManager(true);


            // Load stores and inventory
            var inventoryData = new InventoryData();
            Store FordStore      = new Store("FordStore", "Bucuresti, Str.Palat, nr.1");
            FordStore.Inventory  = inventoryData.LoadFordStoreInventory();
            Store ScodaStore     = new Store("ScodaStore", "Bucuresti, Str. Universitatii nr.1");
            ScodaStore.Inventory = inventoryData.LoadScodaStoreInventory();

            // Load Customer
            Customer customer = new Customer();
            customer.Name     = "Alex";
            customer.Age      = 27;
            customer.VCC      = 301;
            customer.CardNumber = "3400 3749 9403 009";


            // --- Start business logic ---
            // Order Ford Focus 2015 from Ford Store
            dataWriteManager.WriteLine("Order car from Ford Store?");
            dataWriteManager.ReadLine();

            // Find available model in ford store
            Car fordOrderedCar = FordStore.FindCarByModelAndYear("Ford Focus", 2015);
            if (fordOrderedCar != null)
            {
                // Make order
                FordStore.StoreCustomerOrder(customer, fordOrderedCar);
                
                // Receive order details
                FordStore.PrintCustomerOrders(customer);
            }

            // Order Ford Focus 2015 from Scoda Store
            dataWriteManager.WriteLine("Order car from Scoda Store?");
            dataWriteManager.ReadLine();

            // Find available model in scoda store
            Car scodaOrderedCar = ScodaStore.FindCarByModelAndYear("Ford Focus", 2015);
            if (scodaOrderedCar != null)
            {
                // Make order
                ScodaStore.StoreCustomerOrder(customer, scodaOrderedCar);
                
                // Receive order details
                ScodaStore.PrintCustomerOrders(customer);
            }


            // Cancel FordStore Order
            dataWriteManager.WriteLine("Cancel Ford Store order?");
            dataWriteManager.ReadLine();

            FordStore.CancelCustomerOrder(customer, fordOrderedCar);
            

            // make today 3 weeks in future
            DateTime todayDate = DateTime.Now.AddDays(21);
            // Deliver Car on date
            ScodaStore.DeliverCustomerCar(customer, todayDate);
            dataWriteManager.WriteLine("3 weeks has passed Scoda Store deliverd your car. Payment has been made. Thank you!");
            dataWriteManager.ReadLine();          
        }
    }
}
