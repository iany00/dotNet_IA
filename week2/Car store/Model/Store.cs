using System;
using System.Collections.Generic;
using System.Text;

namespace Car_store
{
    class Store : IStore
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Car> Inventory { get; set; }
        public List<Order> OrderList { get; set; }

        public Store(string name, string address)
        {
            this.Name    = name;
            this.Address = address;
        }

        /**
         * Find car by model and year
         * Car should be available and not reserved
         */
        internal Car FindCarByModelAndYear(string model, int year)
        {
            foreach (var car in this.Inventory)
            {
                if(car.Model == model && car.Year == year && car.Reserved == false && car.Available == true)
                {
                    return car;
                }
            }
            return null;
        }

        /**
         * Store new order for store
         */
        public void StoreCustomerOrder(Customer customer, Car orderedCar)
        {
            Order order = new Order(customer, orderedCar);
            this.OrderList = new List<Order>();
            this.OrderList.Add(order);
        }

        /*
         * Find Customer Car order and cancel the order
         */
        public void CancelCustomerOrder(Customer customer, Car orderedCar)
        {
            DataWriteManager dataWriteManager = new DataWriteManager();

            Order customerOrder = this.FindCustomerOrder(customer, orderedCar);
            if (customerOrder != null)
            {
                customerOrder.Cancel();
                dataWriteManager.WriteLine("Car order canceled!");
            }
            dataWriteManager.WriteLine("\n");
        }


        /**
         * Find Customer order
         */
        private Order FindCustomerOrder(Customer customer, Car orderedCar)
        {
            Order customerOrder = this.OrderList.Find(o => (o.Customer == customer) && (o.Car == orderedCar));
            if (customerOrder != null)
            {
                return customerOrder;
            }

            DataWriteManager dataWriteManager = new DataWriteManager();
            dataWriteManager.WriteLine("Customer order not found!", LogLevel.ERROR);

            return null;
        }

        /**
         * Make customer delivery
         */
        internal void DeliverCustomerCar(Customer customer, DateTime todayDate)
        {
            foreach (var order in this.OrderList)
            {
                if (order.Customer == customer && order.DeliverDate >= todayDate)
                {
                    order.DeliverCar();
                }
            }
        }


        /**
         * Print this store order details
         */
        public void PrintOrder(Order order)
        {
            DataWriteManager dataWriteManager = new DataWriteManager();
            dataWriteManager.WriteLine($"{this.Name} Order details:");
            dataWriteManager.WriteLine("________________");

            order.Print();

            dataWriteManager.WriteLine("\n");
        }

        /**
         * Print customer all orders for this store
         */
        public void PrintCustomerOrders(Customer customer)
        {
            DataWriteManager dataWriteManager = new DataWriteManager();
            dataWriteManager.WriteLine($"{this.Name} Order details:");
            dataWriteManager.WriteLine("________________");
            
            // Print customer
            customer.Print();
            dataWriteManager.WriteLine("________________");

            foreach (var order in this.OrderList)
            {
                order.Print();
                dataWriteManager.WriteLine("\n");
            }
        }
    }
}
